SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[usp_purchaseInsert] 
    @rec_no BIGINT,
    @rec_date datetime = NULL,
    @led_id BIGINT = NULL,
    @pm_id BIGINT = NULL,
	@ob_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @rec_billamt decimal(12, 2),
    @rec_receivedamt decimal(12, 2),
    @rec_newbalance decimal(12, 2),
    @rec_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[receipt] ([rec_no], [rec_date], [led_id], [pm_id],ob_id, [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose])
	SELECT @rec_no, @rec_date, @led_id, @pm_id,@ob_id, @com_id, @rec_billamt, @rec_receivedamt, @rec_newbalance, @rec_isclose
	
	if(@pm_id>0)
	begin
		update purchasemaster set pm_received=pm_received+@rec_receivedamt,pm_isclose=@rec_isclose where pm_id=@pm_id
	end
	if(@ob_id>0)
	begin
		update openingbalance set ob_received=ob_received+@rec_receivedamt,ob_isclose=@rec_isclose where ob_id=@ob_id
	end

	-- Begin Return Select <- do not remove
	SELECT [id], [rec_no], [rec_date], [led_id], [@pm_id],ob_id, [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose]
	FROM   [dbo].[purchase]
	WHERE  [id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT