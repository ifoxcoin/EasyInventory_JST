USE [Easyinv];
GO
	
	--04th july 2020


	ALTER TABLE [Easyinv].[dbo].[item] add item_serial int 

	GO

	ALTER PROC [dbo].[usp_itemInsert] 
    @item_code nvarchar(100),
	@item_serial int,
    @item_name nvarchar(100),
    @cat_id BIGINT,
    @item_purchaserate decimal(18, 3),
    @item_costrate decimal(18, 3),
    @item_mrp decimal(18, 3),
    @item_wholesalerate decimal(18, 3),
    @item_specialrate decimal(18, 3),
    @item_supersepecialrate decimal(18, 3),
    @users_uid BIGINT,
    @com_id BIGINT,
    @item_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[item] ([item_code],[item_serial], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate])
	SELECT @item_code,@item_serial, @item_name, @cat_id, @item_purchaserate, @item_costrate, @item_mrp, @item_wholesalerate, @item_specialrate, @item_supersepecialrate, @users_uid, @com_id, @item_udate
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code],[item_serial], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT

GO

ALTER PROC [dbo].[usp_itemSelect] 
    @item_id BIGINT=null,
    @search nvarchar(50)=null,
    @cat_id BIGINT =null,
	@item_code nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [item_id], [item_code],[item_serial], [item_name], im.cat_id,c.cat_name,[item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], im.users_uid,u.users_name , com.com_id,com.com_name, [item_udate] 
	FROM   [dbo].[item] im
	join category c on im.cat_id =c.cat_id
	join company  com on im.com_id  =com.com_id 
	join users  u on im.users_uid =u.users_uid
	WHERE  ([item_id] = @item_id OR @item_id=0 OR @item_id IS NULL) 
	AND (c.cat_id = @cat_id OR @cat_id=0 OR @cat_id IS NULL) 	
	AND item_id<>0
	AND (item_name like '%'+@search+'%' or  @search='' or @search IS NULL)
	AND (item_code like '%'+@item_code+'%' or  @item_code='' or @item_code  IS NULL)
	COMMIT

GO

ALTER PROC [dbo].[usp_itemUpdate] 
    @item_id BIGINT,
    @item_code nvarchar(100),
	@item_serial int,
    @item_name nvarchar(100),
    @cat_id BIGINT,
    @item_purchaserate decimal(18, 3),
    @item_costrate decimal(18, 3),
    @item_mrp decimal(18, 3),
    @item_wholesalerate decimal(18, 3),
    @item_specialrate decimal(18, 3),
    @item_supersepecialrate decimal(18, 3),
    @users_uid BIGINT,
    @com_id BIGINT,
    @item_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[item]
	SET    [item_code] = @item_code,item_serial=@item_serial, [item_name] = @item_name, [cat_id] = @cat_id, [item_purchaserate] = @item_purchaserate, [item_costrate] = @item_costrate, [item_mrp] = @item_mrp, [item_wholesalerate] = @item_wholesalerate, [item_specialrate] = @item_specialrate, [item_supersepecialrate] = @item_supersepecialrate, [users_uid] = @users_uid, [com_id] = @com_id, [item_udate] = @item_udate
	WHERE  [item_id] = @item_id
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code],[item_serial], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = @item_id	
	-- End Return Select <- do not remove

	COMMIT

Go
ALTER PROC [dbo].[usp_stockReport] 
    @item_id BIGINT=null,
    @cat_id BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	select * from (
	SELECT  st.[item_id], sum([stock_addqty]) as AddQty, sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as Stock
	FROM   [dbo].[stock] st		
	group by st.item_id ) as A	
	JOIN item im on im.item_id=A.item_id
	JOIN category ct on ct.cat_id=im.cat_id
	WHERE  (im.item_id = @item_id OR @item_id=0 OR @item_id IS NULL) 	
	AND  (ct.cat_id = @cat_id OR @cat_id=0 OR @cat_id IS NULL) 	
	AND stock>0
	order by im.item_serial,CONVERT(int, im.item_code) asc
	COMMIT

GO

ALTER PROC [dbo].[usp_stockSelect] 
    @item_id BIGINT=null,
    @refid BIGINT=null,
    @stockfrom nvarchar(10)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT  im.[item_id], sum([stock_addqty]) as AddQty, sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as stock
	FROM   [dbo].[stock] s
	JOIN item im on im.item_id=s.item_id
	WHERE  (im.item_id = @item_id OR @item_id IS NULL) 
	AND ([refid] = @refid OR @refid IS NULL) 
	AND (stockfrom = @stockfrom OR @stockfrom IS NULL) 
	group by im.item_id,im.item_serial,im.item_code
	order by im.item_serial,CONVERT(int, im.item_code) asc
	COMMIT

GO

	--05th july 2020

CREATE TABLE [dbo].[openingbalance](
	[ob_id] [bigint] IDENTITY(1,1) NOT NULL,
	[ob_bookno] [nvarchar](100) NOT NULL DEFAULT (''),
	[ob_refno] [bigint] NOT NULL DEFAULT (''),
	[ob_date] [datetime] NULL,
	[led_id] [bigint] NULL,
	[ob_totamount] [decimal](18, 3) NOT NULL DEFAULT (''),
	[ob_profit] [decimal](18, 3) NOT NULL DEFAULT (''),
	[ob_disamount] [decimal](18, 3) NOT NULL DEFAULT (''),
	[ob_packingcharge] [decimal](18, 3) NOT NULL DEFAULT (''),
	[ob_netamount] [decimal](18, 3) NOT NULL DEFAULT (''),
	[ob_received] [decimal](18, 3) NOT NULL DEFAULT (''),
	[ob_isclose] [bit] NULL DEFAULT ((0)),
	[users_uid] [bigint] NULL,
	[ob_udate] [datetime] NULL DEFAULT (getdate()),
	[ob_desc] [nvarchar](50) NULL,
	[ob_paidpacking] [decimal](18, 3) NOT NULL DEFAULT ((0)),
	[ob_paidcommission] [decimal](18, 3) NOT NULL DEFAULT ((0)),
	[ob_iscommissionclose] [bit] NULL DEFAULT ((0)),
	[ob_ispackingclose] [bit] NULL DEFAULT ((0)),
	[ob_taxamount] [decimal](18, 3) NOT NULL DEFAULT ((0.000)),
	[ob_taxpercentage] [decimal](18, 3) NOT NULL DEFAULT ((0.000)),
	[ob_roundamount] [decimal](18, 3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ob_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[openingbalance]  WITH CHECK ADD FOREIGN KEY([led_id])
REFERENCES [dbo].[ledgermaster] ([led_id])
GO

ALTER TABLE [dbo].[openingbalance]  WITH CHECK ADD FOREIGN KEY([users_uid])
REFERENCES [dbo].[users] ([users_uid])
GO


USE [Easyinv];
GO

IF OBJECT_ID('[dbo].[usp_openingbalanceSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_openingbalanceSelect] 
END 
GO
CREATE PROC [dbo].[usp_openingbalanceSelect] 
    @ob_id BIGINT=null,  
    @led_id BIGINT =null,  
    @fdate DATETIME=NULL,  
    @tdate DATETIME=NULL,  
    @IsClose bit =NULL,  
    @ob_refno BIGINT=null  
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ob_id], [ob_bookno], [ob_refno], [ob_date], ob.[led_id], [ob_totamount], [ob_profit], [ob_disamount], [ob_packingcharge], [ob_netamount], [ob_received], [ob_isclose], ob.[users_uid], [ob_udate], [ob_desc], [ob_paidpacking], [ob_paidcommission], [ob_iscommissionclose], [ob_ispackingclose], [ob_taxamount], [ob_taxpercentage], [ob_roundamount] 
	FROM   [dbo].[openingbalance] ob
	join ledgermaster   lm on ob.led_id =lm .led_id   
	join users  u on ob.users_uid =u.users_uid  
	WHERE  ([ob_id] = @ob_id OR @ob_id IS NULL)   
	AND (ob.[led_id] = @led_id OR @led_id IS NULL or @led_id=0)  
	AND (ob.ob_refno = @ob_refno OR @ob_refno IS NULL or @ob_refno=0)  
	AND (ob.[ob_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)  
	AND (@IsClose IS NULL OR (@IsClose=1 AND ob.ob_received=0) OR (@IsClose=0 AND ob.ob_received<>0))   
	order by ob_id desc  

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_openingbalanceInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_openingbalanceInsert] 
END 
GO
CREATE PROC [dbo].[usp_openingbalanceInsert] 
    @ob_bookno nvarchar(100),
    @ob_refno bigint,
    @ob_date datetime = NULL,
    @led_id bigint = NULL,
    @ob_totamount decimal(18, 3),
    @ob_profit decimal(18, 3),
    @ob_disamount decimal(18, 3),
    @ob_packingcharge decimal(18, 3),
    @ob_netamount decimal(18, 3),
    @ob_received decimal(18, 3),
    @ob_isclose bit = NULL,
    @users_uid bigint = NULL,
    @ob_udate datetime = NULL,
    @ob_desc nvarchar(50) = NULL,
    @ob_paidpacking decimal(18, 3),
    @ob_paidcommission decimal(18, 3),
    @ob_iscommissionclose bit = NULL,
    @ob_ispackingclose bit = NULL,
    @ob_taxamount decimal(18, 3),
    @ob_taxpercentage decimal(18, 3),
    @ob_roundamount decimal(18, 3) = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[openingbalance] ([ob_bookno], [ob_refno], [ob_date], [led_id], [ob_totamount], [ob_profit], [ob_disamount], [ob_packingcharge], [ob_netamount], [ob_received], [ob_isclose], [users_uid], [ob_udate], [ob_desc], [ob_paidpacking], [ob_paidcommission], [ob_iscommissionclose], [ob_ispackingclose], [ob_taxamount], [ob_taxpercentage], [ob_roundamount])
	SELECT @ob_bookno, @ob_refno, @ob_date, @led_id, @ob_totamount, @ob_profit, @ob_disamount, @ob_packingcharge, @ob_netamount, @ob_received, @ob_isclose, @users_uid, @ob_udate, @ob_desc, @ob_paidpacking, @ob_paidcommission, @ob_iscommissionclose, @ob_ispackingclose, @ob_taxamount, @ob_taxpercentage, @ob_roundamount
	
	-- Begin Return Select <- do not remove
	SELECT [ob_id], [ob_bookno], [ob_refno], [ob_date], [led_id], [ob_totamount], [ob_profit], [ob_disamount], [ob_packingcharge], [ob_netamount], [ob_received], [ob_isclose], [users_uid], [ob_udate], [ob_desc], [ob_paidpacking], [ob_paidcommission], [ob_iscommissionclose], [ob_ispackingclose], [ob_taxamount], [ob_taxpercentage], [ob_roundamount]
	FROM   [dbo].[openingbalance]
	WHERE  [ob_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_openingbalanceUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_openingbalanceUpdate] 
END 
GO
CREATE PROC [dbo].[usp_openingbalanceUpdate] 
    @ob_id bigint,
    @ob_bookno nvarchar(100),
    @ob_refno bigint,
    @ob_date datetime = NULL,
    @led_id bigint = NULL,
    @ob_totamount decimal(18, 3),
    @ob_profit decimal(18, 3),
    @ob_disamount decimal(18, 3),
    @ob_packingcharge decimal(18, 3),
    @ob_netamount decimal(18, 3),
    @ob_received decimal(18, 3),
    @ob_isclose bit = NULL,
    @users_uid bigint = NULL,
    @ob_udate datetime = NULL,
    @ob_desc nvarchar(50) = NULL,
    @ob_paidpacking decimal(18, 3),
    @ob_paidcommission decimal(18, 3),
    @ob_iscommissionclose bit = NULL,
    @ob_ispackingclose bit = NULL,
    @ob_taxamount decimal(18, 3),
    @ob_taxpercentage decimal(18, 3),
    @ob_roundamount decimal(18, 3) = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[openingbalance]
	SET    [ob_bookno] = @ob_bookno, [ob_refno] = @ob_refno, [ob_date] = @ob_date, [led_id] = @led_id, [ob_totamount] = @ob_totamount, [ob_profit] = @ob_profit, [ob_disamount] = @ob_disamount, [ob_packingcharge] = @ob_packingcharge, [ob_netamount] = @ob_netamount, [ob_received] = @ob_received, [ob_isclose] = @ob_isclose, [users_uid] = @users_uid, [ob_udate] = @ob_udate, [ob_desc] = @ob_desc, [ob_paidpacking] = @ob_paidpacking, [ob_paidcommission] = @ob_paidcommission, [ob_iscommissionclose] = @ob_iscommissionclose, [ob_ispackingclose] = @ob_ispackingclose, [ob_taxamount] = @ob_taxamount, [ob_taxpercentage] = @ob_taxpercentage, [ob_roundamount] = @ob_roundamount
	WHERE  [ob_id] = @ob_id
	
	-- Begin Return Select <- do not remove
	SELECT [ob_id], [ob_bookno], [ob_refno], [ob_date], [led_id], [ob_totamount], [ob_profit], [ob_disamount], [ob_packingcharge], [ob_netamount], [ob_received], [ob_isclose], [users_uid], [ob_udate], [ob_desc], [ob_paidpacking], [ob_paidcommission], [ob_iscommissionclose], [ob_ispackingclose], [ob_taxamount], [ob_taxpercentage], [ob_roundamount]
	FROM   [dbo].[openingbalance]
	WHERE  [ob_id] = @ob_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_openingbalanceDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_openingbalanceDelete] 
END 
GO
CREATE PROC [dbo].[usp_openingbalanceDelete] 
    @ob_id bigint
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[openingbalance]
	WHERE  [ob_id] = @ob_id

	COMMIT
GO
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------


CREATE TABLE [dbo].[receipt](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[rec_no] [bigint] NOT NULL,
	[rec_date] [datetime] NULL,
	[led_id] [bigint] NULL,
	[sm_id] [bigint] NULL,
	[ob_id] [bigint] NULL,
	[com_id] [bigint] NULL,
	[rec_billamt] [decimal](12, 2) NOT NULL,
	[rec_receivedamt] [decimal](12, 2) NOT NULL,
	[rec_newbalance] [decimal](12, 2) NOT NULL,
	[rec_isclose] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [rec_no]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT (getdate()) FOR [rec_date]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [rec_billamt]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [rec_receivedamt]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [rec_newbalance]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [rec_isclose]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [sm_id]
GO

ALTER TABLE [dbo].[receipt] ADD  DEFAULT ((0)) FOR [ob_id]
GO

ALTER TABLE [dbo].[receipt]  WITH CHECK ADD FOREIGN KEY([com_id])
REFERENCES [dbo].[company] ([com_id])
GO

ALTER TABLE [dbo].[receipt]  WITH CHECK ADD FOREIGN KEY([led_id])
REFERENCES [dbo].[ledgermaster] ([led_id])
GO

--ALTER TABLE [dbo].[receipt]  WITH CHECK ADD FOREIGN KEY([sm_id])
--REFERENCES [dbo].[salesmaster] ([sm_id])
--GO

--ALTER TABLE [dbo].[receipt]  WITH CHECK ADD FOREIGN KEY([sm_id])
--REFERENCES [dbo].[openingbalance] ([ob_id])


GO


ALTER PROC [dbo].[usp_receiptInsert] 
    @rec_no BIGINT,
    @rec_date datetime = NULL,
    @led_id BIGINT = NULL,
    @sm_id BIGINT = NULL,
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
	
	INSERT INTO [dbo].[receipt] ([rec_no], [rec_date], [led_id], [sm_id],ob_id, [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose])
	SELECT @rec_no, @rec_date, @led_id, @sm_id,@ob_id, @com_id, @rec_billamt, @rec_receivedamt, @rec_newbalance, @rec_isclose
	
	if(@sm_id>0)
	begin
		update salesmaster set sm_received=sm_received+@rec_receivedamt,sm_isclose=@rec_isclose where sm_id=@sm_id
	end
	if(@ob_id>0)
	begin
		update openingbalance set ob_received=ob_received+@rec_receivedamt,ob_isclose=@rec_isclose where ob_id=@ob_id
	end

	-- Begin Return Select <- do not remove
	SELECT [id], [rec_no], [rec_date], [led_id], [sm_id],ob_id, [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose]
	FROM   [dbo].[receipt]
	WHERE  [id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT

GO

ALTER PROC [dbo].[usp_receiptSelect] 
    @id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT re.[id],lm.led_name,led_address2, re.[rec_no], [rec_date], re.[led_id], re.[sm_id],re.ob_id, re.[com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose] 
	FROM   [dbo].[receipt] re
	--join salesmaster sm on sm.sm_id=re.sm_id
	join ledgermaster lm on lm.led_id=re.led_id
	WHERE  ([id] = @id OR @id IS NULL) 
	and (re.led_id=@led_id OR @led_id IS NULL or @led_id=0)
	AND (re.[rec_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by id desc
	COMMIT

GO


ALTER PROC [dbo].[usp_receiptUpdate] 
    @id BIGINT,
    @rec_no BIGINT,
    @rec_date datetime = NULL,
    @led_id BIGINT = NULL,
    @sm_id BIGINT = NULL,
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

	UPDATE [dbo].[receipt]
	SET    [rec_no] = @rec_no, [rec_date] = @rec_date, [led_id] = @led_id, [sm_id] = @sm_id,[ob_id] = @ob_id, [com_id] = @com_id, [rec_billamt] = @rec_billamt, [rec_receivedamt] = @rec_receivedamt, [rec_newbalance] = @rec_newbalance, [rec_isclose] = @rec_isclose
	WHERE  [id] = @id
	
	-- Begin Return Select <- do not remove
	SELECT [id], [rec_no], [rec_date], [led_id], [sm_id], [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose]
	FROM   [dbo].[receipt]
	WHERE  [id] = @id	
	-- End Return Select <- do not remove

	COMMIT

GO
ALTER PROC [dbo].[usp_receiptDelete] 
    @id BIGINT,
    @sm_id BIGINT,
	@ob_id BIGINT,
    @receivedamt decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	if(@sm_id>0)
	begin
	update salesmaster set sm_received=sm_received-@receivedamt,sm_isclose=0 where sm_id=@sm_id
	end
	if(@ob_id>0)
	begin
	update openingbalance set ob_received=ob_received-@receivedamt,ob_isclose=0 where ob_id=@ob_id
	end

	DELETE
	FROM   [dbo].[receipt]
	WHERE  [id] = @id

	COMMIT

	GO

	
ALTER PROC [dbo].[usp_LedgerOutstandingRpt] 
    @led_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN	
			Select ID,lm.led_name as LedgerName,TransactionDate,BillNo,BillAmount,Received,Type from 
			(
				SELECT sm.ob_id as ID,sm.led_id ,ob_date as TransactionDate,sm.ob_refno AS BillNo,sm.ob_netamount as BillAmount,0 As Received,'OpeningBalance' As Type from 	 openingbalance sm 
			join ledgermaster lm on lm.led_id=sm.led_id	
			join ledgermaster aglm on lm.led_agid=aglm.led_id	

				UNION ALL

			SELECT sm.sm_id as ID,sm.led_id ,sm_date as TransactionDate,sm.sm_refno AS BillNo,sm.sm_netamount as BillAmount,0 As Received,'Sales' As Type from 	 salesmaster sm 
			join ledgermaster lm on lm.led_id=sm.led_id	
			join ledgermaster aglm on lm.led_agid=aglm.led_id	
			--group by sm.sm_id,lm.led_id,aglm.led_id
			--where sm.led_id=194

			UNION ALL
			
			SELECT re.id as ID,re.led_id,rec_date as TransactionDate,re.rec_no AS BillNo,0 AS BillAmount,re.rec_receivedamt as Received,'Receipt' As Type from 	 receipt re 
			join ledgermaster lm on lm.led_id=re.led_id	
			join ledgermaster aglm on lm.led_agid=aglm.led_id	
			--group by sm.sm_id,lm.led_id,aglm.led_id
			--where re.led_id=194
			) As SubDet 
			JOIN ledgermaster lm on lm.led_id= SubDet.led_id
			where (SubDet.[led_id]=@led_id OR @led_id IS NULL or @led_id=0)	
			AND (SubDet.TransactionDate between @fdate AND @tdate Or @fdate IS NULL OR @tdate IS NULL)

COMMIT

GO


ALTER PROC [dbo].[usp_OutstandingReport] 
    @sm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN	
	select * from (
	SELECT sm.ob_id as sm_id,lm.led_id,lm.led_accountcode,aglm.led_id as agid,DATEDIFF(DAY,sm.ob_date, GETDATE()) as dayscount,[ob_isclose]  ,lm.led_name,lm.led_address,lm.led_address1,lm.led_address2 ,sm.ob_date as sm_date,sm.ob_refno as sm_refno,sm.ob_netamount billamt,ob_received,sm.ob_netamount-ob_received as balanceamt,'OpeningBalance' As Type from 
	openingbalance sm 
	join ledgermaster lm on lm.led_id=sm.led_id	
	join ledgermaster aglm on lm.led_agid=aglm.led_id						
	WHERE  (sm.[ob_id]  = @sm_id OR @sm_id IS NULL) 
	and (aglm.led_id =@led_id OR @led_id IS NULL or @led_id=0)	
	AND (sm.ob_netamount-ob_received)>0
	

	union all

	SELECT sm.sm_id,lm.led_id,lm.led_accountcode,aglm.led_id as agid,DATEDIFF(DAY,sm.sm_date, GETDATE()) as dayscount,[sm_isclose]  ,lm.led_name,lm.led_address,lm.led_address1,lm.led_address2 ,sm.sm_date,sm.sm_refno,sm.sm_netamount billamt,sm_received,sm.sm_netamount-sm_received as balanceamt,'Sales Bill' As Type from 
	salesmaster sm 
	join ledgermaster lm on lm.led_id=sm.led_id	
	join ledgermaster aglm on lm.led_agid=aglm.led_id						
	WHERE  (sm.[sm_id]  = @sm_id OR @sm_id IS NULL) 
	and (aglm.led_id =@led_id OR @led_id IS NULL or @led_id=0)	
	AND (sm.sm_netamount-sm_received)>0
	)as lm
 
	order by CONVERT(int, lm.led_accountcode) asc
	COMMIT

GO


ALTER PROC [dbo].[usp_ledgermasterSelect]   
    @led_id BIGINT=null,  
    @accounttype nvarchar(50)=null,  
    @searchbyname nvarchar(50)=null,  
    @searchbycode nvarchar(50)=null,  
    @led_agid BIGINT=null  
      
AS   
 SET NOCOUNT ON   
 SET XACT_ABORT ON    
  
 BEGIN TRAN  
  
 SELECT [led_id], [led_agid], [led_accountcode], [led_ratetype],[led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], 
  
[led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_disper],[led_refno], lm.users_uid,u.users_name ,com.com_name , lm.com_id, [led_udate]   
 FROM   [dbo].[ledgermaster] lm  
 join company  com on lm .com_id  =com.com_id   
 join users  u on lm.users_uid =u.users_uid   
 WHERE  ([led_id] = @led_id OR @led_id IS NULL)   
 AND led_id<>0  
 AND  (led_accounttype =@accounttype or @accounttype IS NULL)  
 AND (led_name like '%'+@searchbyname+'%' or @searchbyname  IS NULL)  
 AND (led_address2  like @searchbycode +'%' or @searchbycode  IS NULL)  
 AND (led_agid  = @led_agid OR @led_agid IS NULL)  
 --order by led_id DESC  
 order by CONVERT(int,led_accountcode) Asc  
 COMMIT  

