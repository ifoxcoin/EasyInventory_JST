USE EasyInv
IF OBJECT_ID('[dbo].[usp_usersSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_usersSelect] 
END 
GO
CREATE PROC [dbo].[usp_usersSelect] 
    @users_uid BIGINT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [users_uid], [users_name], [users_pwd], [users_date], [users_pid], [users_type], [users_lock] 
	FROM   [dbo].[users] 
	WHERE  ([users_uid] = @users_uid OR @users_uid IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_usersInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_usersInsert] 
END 
GO
CREATE PROC [dbo].[usp_usersInsert] 
    @users_name nvarchar(25),
    @users_pwd nvarchar(50),
    @users_pid BIGINT,
    @users_type char(1),
    @users_lock char(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[users] ([users_name], [users_pwd], [users_date], [users_pid], [users_type], [users_lock])
	SELECT @users_name, @users_pwd, GETDATE(), @users_pid, @users_type, @users_lock

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_usersUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_usersUpdate] 
END 
GO
CREATE PROC [dbo].[usp_usersUpdate] 
    @users_uid BIGINT,
    @users_name nvarchar(25),
    @users_pwd nvarchar(50),
    @users_pid BIGINT,
    @users_type char(1),
    @users_lock char(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[users]
	SET    [users_name] = @users_name, [users_pwd] = @users_pwd, [users_date] = GETDATE(), [users_pid] = @users_pid, [users_type] = @users_type, [users_lock] = @users_lock
	WHERE  [users_uid] = @users_uid
	
	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_usersDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_usersDelete] 
END 
GO
CREATE PROC [dbo].[usp_usersDelete] 
    @users_uid BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[users]
	WHERE  [users_uid] = @users_uid

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_rightsInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_rightsInsert]
END 
GO
create proc usp_rightsInsert
	@formcode BIGINT=NULL,
	@ucode BIGINT=NULL,
	@A Char(1)=NULL,
	@E Char(1)=NULL,
	@D Char(1)=NULL,
	@V Char(1)=NULL,
	@P Char(1)=NULL
AS
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	INSERT INTO rights(
	formcode,
	ucode,
	A,
	E,
	D,
	V,
	P)
	VALUES(
	ISNULL(@formcode,0),
	ISNULL(@ucode,0),
	ISNULL(@A,'N'),
	ISNULL(@E,'N'),
	ISNULL(@D,'N'),
	ISNULL(@V,'N'),
	ISNULL(@P,'N'))
	
	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_rightsDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_rightsDelete]
END 
GO
CREATE PROCEDURE usp_rightsDelete
	@ucode BIGINT=NULL
AS
BEGIN TRAN
	DELETE FROM rights WHERE ucode=@ucode
COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_rightsSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_rightsSelect]
END 
GO
CREATE PROC [dbo].[usp_rightsSelect]
    @rucode BIGINT=null,
    @ucode BIGINT=null
AS
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	select M.modulename,F.formname,isnull(E.A,F.A) A,isnull(E.E,F.E) E,
    isnull(E.D,F.D) D,isnull(E.V,F.V) V,isnull(E.P,F.P) P,
    R.A RA,R.E RE,R.D RD,R.V RV,R.P RP,F.modulecode,F.formcode
    from form F
    join module M on M.modulecode=F.modulecode
    left join rights R on R.formcode=F.formcode and R.ucode=@rucode
    left join rights E on E.formcode=F.formcode and E.ucode=@ucode
    where @ucode<>0 and (@ucode=@ucode or @ucode is null)
    order by M.modulename,F.formname
    
	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_companySelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_companySelect] 
END 
GO
CREATE PROC [dbo].[usp_companySelect] 
    @com_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [com_id], [com_name], [com_add1], [com_add2], [com_add3], [com_city], [com_state], [com_country], [com_phone], [com_mobile1], [com_mobile2], [com_fax], [com_pin], [com_email], [com_web], [com_default], [com_tin], [com_cstdate], [com_cst] , [com_pan] 
	FROM   [dbo].[company] 
	WHERE  ([com_id] = @com_id OR @com_id IS NULL) 
	ORDER BY [com_default] desc, [com_name]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_companyInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_companyInsert] 
END 
GO
CREATE PROC [dbo].[usp_companyInsert] 
    @com_name nvarchar(100),
    @com_add1 nvarchar(50),
    @com_add2 nvarchar(50),
    @com_add3 nvarchar(50),
    @com_city nvarchar(50),
    @com_state nvarchar(50),
    @com_country nvarchar(50),
    @com_phone nvarchar(50),
    @com_mobile1 nvarchar(15),
    @com_mobile2 nvarchar(15),
    @com_fax nvarchar(50),
    @com_pin nvarchar(7),
    @com_email nvarchar(50),
    @com_web nvarchar(50),
    @com_default char(1),
    @com_tin nvarchar(50),
    @com_cst nvarchar(50),
    @com_cstdate date,
    @com_pan nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[company] ([com_name], [com_add1], [com_add2], [com_add3], [com_city], [com_state], [com_country], [com_phone], [com_mobile1], [com_mobile2], [com_fax], [com_pin], [com_email], [com_web], [com_default], [com_tin], [com_cst], [com_cstdate], [com_pan])
	SELECT @com_name, @com_add1, @com_add2, @com_add3, @com_city, @com_state, @com_country, @com_phone, @com_mobile1, @com_mobile2, @com_fax, @com_pin, @com_email, @com_web, @com_default, @com_tin, @com_cst, @com_cstdate, @com_pan
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_companyUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_companyUpdate] 
END 
GO
CREATE PROC [dbo].[usp_companyUpdate] 
    @com_id BIGINT,
    @com_name nvarchar(100),
    @com_add1 nvarchar(50),
    @com_add2 nvarchar(50),
    @com_add3 nvarchar(50),
    @com_city nvarchar(50),
    @com_state nvarchar(50),
    @com_country nvarchar(50),
    @com_phone nvarchar(50),
    @com_mobile1 nvarchar(15),
    @com_mobile2 nvarchar(15),
    @com_fax nvarchar(50),
    @com_pin nvarchar(7),
    @com_email nvarchar(50),
    @com_web nvarchar(50),
    @com_default char(1),
    @com_tin nvarchar(50),
    @com_cst nvarchar(50),
    @com_cstdate date,
    @com_pan nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[company]
	SET    [com_name] = @com_name, [com_add1] = @com_add1, [com_add2] = @com_add2, [com_add3] = @com_add3, [com_city] = @com_city, [com_state] = @com_state, [com_country] = @com_country, [com_phone] = @com_phone, [com_mobile1] = @com_mobile1, [com_mobile2] = @com_mobile2, [com_fax] = @com_fax, [com_pin] = @com_pin, [com_email] = @com_email, [com_web] = @com_web, [com_default] = @com_default, [com_tin] = @com_tin, [com_cst] = @com_cst, [com_cstdate] = @com_cstdate, [com_pan] = @com_pan
	WHERE  [com_id] = @com_id

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_companyDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_companyDelete] 
END 
GO
CREATE PROC [dbo].[usp_companyDelete] 
    @com_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[company]
	WHERE  [com_id] = @com_id

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_categorySelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_categorySelect] 
END 
GO
CREATE PROC [dbo].[usp_categorySelect] 
    @cat_id BIGINT=null,
    @search nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [cat_id], [cat_name], [com_id], [users_uid], [cat_udate] 
	FROM   [dbo].[category] 
	WHERE  ([cat_id] = @cat_id OR @cat_id IS NULL) 
	AND cat_id<> 0
	AND (cat_name like '%'+@search+'%' or @search IS NULL)

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_categoryInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_categoryInsert] 
END 
GO
CREATE PROC [dbo].[usp_categoryInsert] 
    @cat_name nvarchar(100),
    @com_id BIGINT,
    @users_uid BIGINT,
    @cat_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[category] ([cat_name], [com_id], [users_uid], [cat_udate])
	SELECT @cat_name, @com_id, @users_uid, @cat_udate
	
	-- Begin Return Select <- do not remove
	SELECT [cat_id], [cat_name], [com_id], [users_uid], [cat_udate]
	FROM   [dbo].[category]
	WHERE  [cat_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_categoryUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_categoryUpdate] 
END 
GO
CREATE PROC [dbo].[usp_categoryUpdate] 
    @cat_id BIGINT,
    @cat_name nvarchar(100),
    @com_id BIGINT,
    @users_uid BIGINT,
    @cat_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[category]
	SET    [cat_name] = @cat_name, [com_id] = @com_id, [users_uid] = @users_uid, [cat_udate] = @cat_udate
	WHERE  [cat_id] = @cat_id
	
	-- Begin Return Select <- do not remove
	SELECT [cat_id], [cat_name], [com_id], [users_uid], [cat_udate]
	FROM   [dbo].[category]
	WHERE  [cat_id] = @cat_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_categoryDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_categoryDelete] 
END 
GO
CREATE PROC [dbo].[usp_categoryDelete] 
    @cat_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[category]
	WHERE  [cat_id] = @cat_id

	COMMIT
GO



IF OBJECT_ID('[dbo].[usp_itemSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemSelect] 
END 
GO
CREATE PROC [dbo].[usp_itemSelect] 
    @item_id BIGINT=null,
    @search nvarchar(50)=null,
    @cat_id BIGINT =null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [item_id], [item_code], [item_name], im.cat_id,c.cat_name,[item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], im.users_uid,u.users_name , com.com_id,com.com_name, [item_udate] 
	FROM   [dbo].[item] im
	join category c on im.cat_id =c.cat_id
	join company  com on im.com_id  =com.com_id 
	join users  u on im.users_uid =u.users_uid
	WHERE  ([item_id] = @item_id OR @item_id=0 OR @item_id IS NULL) 
	AND (c.cat_id = @cat_id OR @cat_id=0 OR @cat_id IS NULL) 
	AND item_id<>0
	AND (item_name like '%'+@search+'%' or  @search='' or @search IS NULL)
	order by item_id asc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_itemInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemInsert] 
END 
GO
CREATE PROC [dbo].[usp_itemInsert] 
    @item_code nvarchar(100),
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
	
	INSERT INTO [dbo].[item] ([item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate])
	SELECT @item_code, @item_name, @cat_id, @item_purchaserate, @item_costrate, @item_mrp, @item_wholesalerate, @item_specialrate, @item_supersepecialrate, @users_uid, @com_id, @item_udate
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_itemUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemUpdate] 
END 
GO
CREATE PROC [dbo].[usp_itemUpdate] 
    @item_id BIGINT,
    @item_code nvarchar(100),
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
	SET    [item_code] = @item_code, [item_name] = @item_name, [cat_id] = @cat_id, [item_purchaserate] = @item_purchaserate, [item_costrate] = @item_costrate, [item_mrp] = @item_mrp, [item_wholesalerate] = @item_wholesalerate, [item_specialrate] = @item_specialrate, [item_supersepecialrate] = @item_supersepecialrate, [users_uid] = @users_uid, [com_id] = @com_id, [item_udate] = @item_udate
	WHERE  [item_id] = @item_id
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = @item_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_itemDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemDelete] 
END 
GO
CREATE PROC [dbo].[usp_itemDelete] 
    @item_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[item]
	WHERE  [item_id] = @item_id

	COMMIT
GO



IF OBJECT_ID('[dbo].[usp_ledgermasterSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ledgermasterSelect] 
END 
GO
CREATE PROC [dbo].[usp_ledgermasterSelect] 
    @led_id BIGINT=null,
    @accounttype nvarchar(50)=null,
    @searchbyname nvarchar(50)=null,
    @searchbycode nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [led_id], [led_agid], [led_accountcode], [led_ratetype],[led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_disper],[led_refno], lm.users_uid,u.users_name ,com.com_name , lm.com_id, [led_udate] 
	FROM   [dbo].[ledgermaster] lm
	join company  com on lm .com_id  =com.com_id 
	join users  u on lm.users_uid =u.users_uid	
	WHERE  ([led_id] = @led_id OR @led_id IS NULL) 
	AND led_id<>0
	AND  (led_accounttype =@accounttype or @accounttype IS NULL)
	AND (led_name like '%'+@searchbyname+'%' or @searchbyname  IS NULL)
	AND (led_address2  like '%'+@searchbycode +'%' or @searchbycode  IS NULL)
	order by led_id DESC
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ledgermasterInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ledgermasterInsert] 
END 
GO
CREATE PROC [dbo].[usp_ledgermasterInsert] 
    @led_agid BIGINT = NULL,
    @led_accountcode nvarchar(100),
    @led_accounttype nvarchar(100),
    @led_name nvarchar(100),
    @led_address nvarchar(100),
    @led_address1 nvarchar(100),
    @led_address2 nvarchar(100),
    @led_tname nvarchar(100),
    @led_taddress nvarchar(100),
    @led_taddress1 nvarchar(100),
    @led_taddress2 nvarchar(100),
    @led_pincode nvarchar(100),
    @led_transport nvarchar(100),
    @led_ownerphone nvarchar(100),
    @led_ownername nvarchar(100),
    @led_managername nvarchar(100),
    @led_managerphone nvarchar(100),
    @led_tin nvarchar(100),
    @led_cst nvarchar(100),
    @led_refno nvarchar(100),
    @users_uid BIGINT = NULL,
    @com_id BIGINT = NULL,
    @led_udate datetime = NULL,
    @led_ratetype nvarchar(100),
     @led_disper decimal(8,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[ledgermaster] ([led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [users_uid], [com_id], [led_udate], [led_ratetype], [led_disper])
	SELECT @led_agid, @led_accountcode, @led_accounttype, @led_name, @led_address, @led_address1, @led_address2, @led_tname, @led_taddress, @led_taddress1, @led_taddress2, @led_pincode, @led_transport, @led_ownerphone, @led_ownername, @led_managername, @led_managerphone, @led_tin, @led_cst, @led_refno, @users_uid, @com_id, @led_udate, @led_ratetype, @led_disper
	
	-- Begin Return Select <- do not remove
	SELECT [led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [users_uid], [com_id], [led_udate], [led_ratetype], [led_disper]
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ledgermasterUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ledgermasterUpdate] 
END 
GO
CREATE PROC [dbo].[usp_ledgermasterUpdate] 
    @led_id BIGINT,
    @led_agid BIGINT = NULL,
    @led_accountcode nvarchar(100),
    @led_accounttype nvarchar(100),
    @led_name nvarchar(100),
    @led_address nvarchar(100),
    @led_address1 nvarchar(100),
    @led_address2 nvarchar(100),
    @led_tname nvarchar(100),
    @led_taddress nvarchar(100),
    @led_taddress1 nvarchar(100),
    @led_taddress2 nvarchar(100),
    @led_pincode nvarchar(100),
    @led_transport nvarchar(100),
    @led_ownerphone nvarchar(100),
    @led_ownername nvarchar(100),
    @led_managername nvarchar(100),
    @led_managerphone nvarchar(100),
    @led_tin nvarchar(100),
    @led_cst nvarchar(100),
    @led_refno nvarchar(100),
    @users_uid BIGINT = NULL,
    @com_id BIGINT = NULL,
    @led_udate datetime = NULL,
    @led_ratetype nvarchar(100),
    @led_disper decimal(8,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[ledgermaster]
	SET    [led_agid] = @led_agid, [led_accountcode] = @led_accountcode, [led_accounttype] = @led_accounttype, [led_name] = @led_name, [led_address] = @led_address, [led_address1] = @led_address1, [led_address2] = @led_address2, [led_tname] = @led_tname, [led_taddress] = @led_taddress, [led_taddress1] = @led_taddress1, [led_taddress2] = @led_taddress2, [led_pincode] = @led_pincode, [led_transport] = @led_transport, [led_ownerphone] = @led_ownerphone, [led_ownername] = @led_ownername, [led_managername] = @led_managername, [led_managerphone] = @led_managerphone, [led_tin] = @led_tin, [led_cst] = @led_cst, [led_refno] = @led_refno, [users_uid] = @users_uid, [com_id] = @com_id, [led_udate] = @led_udate, [led_ratetype] = @led_ratetype,[led_disper]=@led_disper
	WHERE  [led_id] = @led_id
	
	-- Begin Return Select <- do not remove
	SELECT [led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [users_uid], [com_id], [led_udate], [led_ratetype],[led_disper]
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = @led_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ledgermasterDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ledgermasterDelete] 
END 
GO
CREATE PROC [dbo].[usp_ledgermasterDelete] 
    @led_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = @led_id

	COMMIT
GO

IF OBJECT_ID('[dbo].[fnSplit]') IS NOT NULL
BEGIN 
    DROP FUNCTION [dbo].[fnSplit] 
END
GO
CREATE FUNCTION [dbo].[fnSplit](
    @sInputList VARCHAR(8000) -- List of delimited items
	,@sDelimiter VARCHAR(8000) = ',' -- delimiter that separates items
	) RETURNS @List TABLE (item VARCHAR(8000))
	BEGIN
	DECLARE @sItem VARCHAR(8000)
	WHILE CHARINDEX(@sDelimiter,@sInputList,0) <> 0
	 BEGIN
	 SELECT
	  @sItem=RTRIM(LTRIM(SUBSTRING(@sInputList,1,CHARINDEX(@sDelimiter,@sInputList,0)-1))),
	  @sInputList=RTRIM(LTRIM(SUBSTRING(@sInputList,CHARINDEX(@sDelimiter,@sInputList,0)+LEN(@sDelimiter),LEN(@sInputList))))
	 
	 IF LEN(@sItem) > 0
	  INSERT INTO @List SELECT @sItem
	 END

	IF LEN(@sInputList) > 0
	 INSERT INTO @List SELECT @sInputList -- Put the last item in
	RETURN
	END
GO


IF OBJECT_ID('[dbo].[usp_purchasemasterSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasemasterSelect] 
END 
GO
CREATE PROC [dbo].[usp_purchasemasterSelect] 
    @pm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATETIME=NULL,
    @tdate DATETIME=NULL,
    @pm_no  BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [pm_id], [pm_no], [pm_date], pm.led_id,lm.led_address2,lm.led_pincode,lm.led_tin,led_cst,lm.led_name,lm.led_address,lm.led_address1,lm.led_transport,lm.led_ownerphone, [pm_totqty], [pm_totamount], pm.users_uid,u.users_name , [pm_udate], [pm_desc], pm.com_id ,com.com_name ,pm_isclose
	FROM   [dbo].[purchasemaster] pm
	join ledgermaster   lm on pm.led_id =lm .led_id 
	join company  com on pm.com_id  =com.com_id 
	join users  u on pm.users_uid =u.users_uid
	WHERE  ([pm_id] = @pm_id OR @pm_id IS NULL) 
	AND (pm.[led_id] = @led_id OR @led_id IS NULL or @led_id=0)
	AND (pm.pm_no = @pm_no OR @pm_no IS NULL or @pm_no=0)
	AND (pm.[pm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by pm_id desc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_purchasemasterInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasemasterInsert] 
END 
GO
CREATE PROC [dbo].[usp_purchasemasterInsert] 
  @pm_id BIGINT output,
    @pm_no BIGINT,
    @pm_date datetime = NULL,
    @led_id BIGINT = NULL,
    @pm_totqty decimal(18, 3),
    @pm_totamount decimal(18, 3),
    @com_id BIGINT = NULL,
    @users_uid BIGINT = NULL,
    @pm_udate datetime = NULL,
    @pm_desc nvarchar(50) = NULL,
    @pm_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN 
	
	INSERT INTO [dbo].[purchasemaster] ([pm_no], [pm_date], [led_id], [pm_totqty], [pm_totamount], [com_id], [users_uid], [pm_udate], [pm_desc], [pm_isclose])
	SELECT @pm_no, @pm_date, @led_id, @pm_totqty, @pm_totamount, @com_id, @users_uid, @pm_udate, @pm_desc, @pm_isclose
	
	-- Begin Return Select <- do not remove
	SELECT [pm_id], [pm_no], [pm_date], [led_id], [pm_totqty], [pm_totamount], [com_id], [users_uid], [pm_udate], [pm_desc], [pm_isclose]
	FROM   [dbo].[purchasemaster]
	WHERE  [pm_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
	
       set @pm_id = SCOPE_IDENTITY()
        return  @pm_id      
	END
GO
IF OBJECT_ID('[dbo].[usp_purchasemasterUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasemasterUpdate] 
END 
GO
CREATE PROC [dbo].[usp_purchasemasterUpdate] 
    @pm_id BIGINT,
    @pm_no BIGINT,
    @pm_date datetime = NULL,
    @led_id BIGINT = NULL,
    @pm_totqty decimal(18, 3),
    @pm_totamount decimal(18, 3),
    @com_id BIGINT = NULL,
    @users_uid BIGINT = NULL,
    @pm_udate datetime = NULL,
    @pm_desc nvarchar(50) = NULL,
    @pm_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[purchasemaster]
	SET    [pm_no] = @pm_no, [pm_date] = @pm_date, [led_id] = @led_id, [pm_totqty] = @pm_totqty, [pm_totamount] = @pm_totamount, [com_id] = @com_id, [users_uid] = @users_uid, [pm_udate] = @pm_udate, [pm_desc] = @pm_desc, [pm_isclose] = @pm_isclose
	WHERE  [pm_id] = @pm_id
	
	-- Begin Return Select <- do not remove
	SELECT [pm_id], [pm_no], [pm_date], [led_id], [pm_totqty], [pm_totamount], [com_id], [users_uid], [pm_udate], [pm_desc], [pm_isclose]
	FROM   [dbo].[purchasemaster]
	WHERE  [pm_id] = @pm_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_purchasemasterDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasemasterDelete] 
END 
GO
CREATE PROC [dbo].[usp_purchasemasterDelete] 
    @pm_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[purchasemaster]
	WHERE  [pm_id] = @pm_id

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_purchasedetailsSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasedetailsSelect] 
END 
GO
CREATE PROC [dbo].[usp_purchasedetailsSelect] 
    @pm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATETIME=NULL,
    @tdate DATETIME=NULL,
    @item_id BIGINT=NULL,
    @cat_id BIGINT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [pd_id], pd.pm_id,pm.pm_no,pm.pm_totamount,pm.pm_totqty,pm.pm_date, pd.item_id,im.item_name , pd.cat_id,cat.cat_name, [pd_particulars], [pd_qty], [pd_prate], [pd_amount] 
	FROM   [dbo].[purchasedetails] pd
	join purchasemaster pm on pm.pm_id=pd.pm_id
	join item    im on pd.item_id  =im .item_id  
	join category  cat on pd.cat_id  =cat.cat_id 
	WHERE  (pd.[pm_id] = @pm_id OR @pm_id  IS NULL) 
	AND (pd.item_id = @item_id OR @item_id =0 OR @item_id IS NULL)
	AND (im.cat_id = @cat_id OR @cat_id =0 OR @cat_id  IS NULL)
	AND (pm.[led_id] = @led_id OR @led_id IS NULL or @led_id=0)
	AND (pm.[pm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by pm_id desc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_purchasedetailsInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasedetailsInsert] 
END 
GO
CREATE PROC [dbo].[usp_purchasedetailsInsert] 
    @pm_id BIGINT,
    @item_id BIGINT,
    @cat_id BIGINT,
    @pd_particulars nvarchar(100),
    @pd_qty decimal(18, 3),
    @pd_prate decimal(18, 3),
    @pd_amount decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[purchasedetails] ([pm_id], [item_id], [cat_id], [pd_particulars], [pd_qty], [pd_prate], [pd_amount])
	SELECT @pm_id, @item_id, @cat_id, @pd_particulars, @pd_qty, @pd_prate, @pd_amount
	
	-- Begin Return Select <- do not remove
	SELECT [pd_id], [pm_id], [item_id], [cat_id], [pd_particulars], [pd_qty], [pd_prate], [pd_amount]
	FROM   [dbo].[purchasedetails]
	WHERE  [pd_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_purchasedetailsUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasedetailsUpdate] 
END 
GO
CREATE PROC [dbo].[usp_purchasedetailsUpdate] 
    @pd_id BIGINT,
    @pm_id BIGINT,
    @item_id BIGINT,
    @cat_id BIGINT,
    @pd_particulars nvarchar(100),
    @pd_qty decimal(18, 3),
    @pd_prate decimal(18, 3),
    @pd_amount decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[purchasedetails]
	SET    [pm_id] = @pm_id, [item_id] = @item_id, [cat_id] = @cat_id, [pd_particulars] = @pd_particulars, [pd_qty] = @pd_qty, [pd_prate] = @pd_prate, [pd_amount] = @pd_amount
	WHERE  [pd_id] = @pd_id
	
	-- Begin Return Select <- do not remove
	SELECT [pd_id], [pm_id], [item_id], [cat_id], [pd_particulars], [pd_qty], [pd_prate], [pd_amount]
	FROM   [dbo].[purchasedetails]
	WHERE  [pd_id] = @pd_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_purchasedetailsDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_purchasedetailsDelete] 
END 
GO
CREATE PROC [dbo].[usp_purchasedetailsDelete] 
    @pm_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[purchasedetails]
	WHERE  [pm_id] = @pm_id 

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_salesmasterSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesmasterSelect] 
END 
GO
CREATE PROC [dbo].[usp_salesmasterSelect] 
    @sm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATETIME=NULL,
    @tdate DATETIME=NULL,
    @IsClose bit =NULL,
    @sm_refno BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [sm_id], [sm_bookno], [sm_refno], [sm_date], sm.led_id,lm.led_address2,lm.led_pincode,lm.led_tin,led_cst,lm.led_name,lm.led_address,lm.led_address1,lm.led_transport,lm.led_ownerphone, [sm_totqty], [sm_totamount], [sm_itemcount], [sm_profit], [sm_disamount], [sm_packingcharge], [sm_netamount],sm_received,sm_paidcommission,sm_paidcommission,sm_iscommissionclose,sm_ispackingclose, sm.users_uid,u.users_name, [sm_udate], [sm_desc] ,sm_isclose
	FROM   [dbo].[salesmaster] sm
	join ledgermaster   lm on sm.led_id =lm .led_id 
	join users  u on sm.users_uid =u.users_uid
	WHERE  ([sm_id] = @sm_id OR @sm_id IS NULL) 
	AND (sm.[led_id] = @led_id OR @led_id IS NULL or @led_id=0)
	AND (sm.sm_refno = @sm_refno OR @sm_refno IS NULL or @sm_refno=0)
	AND (sm.[sm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	AND (@IsClose IS NULL OR (@IsClose=1 AND sm.sm_received=0) OR (@IsClose=0 AND sm.sm_received<>0))	
	order by sm_id desc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_salesmasterInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesmasterInsert] 
END 
GO
CREATE PROC [dbo].[usp_salesmasterInsert] 
    @sm_id BIGINT output,
    @sm_bookno nvarchar(100),
    @sm_refno bigint,
    @sm_date datetime = NULL,
    @led_id BIGINT = NULL,
    @sm_totqty decimal(18, 3),
    @sm_totamount decimal(18, 3),
    @sm_itemcount BIGINT = NULL,
    @sm_profit decimal(18, 3),
    @sm_disamount decimal(18, 3),
    @sm_packingcharge decimal(18, 3),
    @sm_netamount decimal(18, 3),
    @sm_received decimal(18, 3),
    @sm_paidcommission decimal(18, 3), 
    @sm_paidpacking decimal(18, 3), 
    @sm_iscommissionclose bit = NULL,   
    @sm_ispackingclose bit = NULL,
    @users_uid BIGINT = NULL,
    @sm_udate datetime = NULL,
    @sm_desc nvarchar(50) = NULL,
    @sm_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN 
	
	INSERT INTO [dbo].[salesmaster] ([sm_bookno], [sm_refno], [sm_date], [led_id], [sm_totqty], [sm_totamount], [sm_itemcount], [sm_profit], [sm_disamount], [sm_packingcharge], [sm_netamount], sm_received,sm_paidcommission,sm_paidpacking,sm_iscommissionclose,sm_ispackingclose,[users_uid], [sm_udate], [sm_desc], [sm_isclose])
	SELECT @sm_bookno, @sm_refno, @sm_date, @led_id, @sm_totqty, @sm_totamount, @sm_itemcount, @sm_profit, @sm_disamount, @sm_packingcharge, @sm_netamount,@sm_received,@sm_paidcommission,@sm_paidpacking,@sm_iscommissionclose,@sm_ispackingclose, @users_uid, @sm_udate, @sm_desc, @sm_isclose
	
	-- Begin Return Select <- do not remove
	SELECT [sm_id], [sm_bookno], [sm_refno], [sm_date], [led_id], [sm_totqty], [sm_totamount], [sm_itemcount], [sm_profit], [sm_disamount], [sm_packingcharge], [sm_netamount],sm_received,sm_paidcommission,sm_paidpacking,sm_iscommissionclose,sm_ispackingclose, [users_uid], [sm_udate], [sm_desc], [sm_isclose]
	FROM   [dbo].[salesmaster]
	WHERE  [sm_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
        set @sm_id     = SCOPE_IDENTITY()
        return  @sm_id  
        
        
        
	END
GO
IF OBJECT_ID('[dbo].[usp_salesmasterUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesmasterUpdate] 
END 
GO
CREATE PROC [dbo].[usp_salesmasterUpdate] 
    @sm_id BIGINT,
    @sm_bookno nvarchar(100),
    @sm_refno bigint,
    @sm_date datetime = NULL,
    @led_id BIGINT = NULL,
    @sm_totqty decimal(18, 3),
    @sm_totamount decimal(18, 3),
    @sm_itemcount BIGINT = NULL,
    @sm_profit decimal(18, 3),
    @sm_disamount decimal(18, 3),
    @sm_packingcharge decimal(18, 3),
    @sm_netamount decimal(18, 3),
    @sm_received decimal(18, 3),
    @sm_paidcommission decimal(18, 3), 
    @sm_paidpacking decimal(18, 3), 
    @sm_iscommissionclose bit = NULL,   
    @sm_ispackingclose bit = NULL,   
    @users_uid BIGINT = NULL,
    @sm_udate datetime = NULL,
    @sm_desc nvarchar(50) = NULL,
    @sm_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[salesmaster]
	SET    [sm_bookno] = @sm_bookno, [sm_refno] = @sm_refno, [sm_date] = @sm_date, [led_id] = @led_id, [sm_totqty] = @sm_totqty, [sm_totamount] = @sm_totamount, [sm_itemcount] = @sm_itemcount, [sm_profit] = @sm_profit, [sm_disamount] = @sm_disamount, [sm_packingcharge] = @sm_packingcharge, [sm_netamount] = @sm_netamount, sm_received=@sm_received,sm_paidcommission=@sm_paidcommission,sm_paidpacking=@sm_paidpacking,sm_iscommissionclose=@sm_iscommissionclose,sm_ispackingclose=@sm_ispackingclose,[users_uid] = @users_uid, [sm_udate] = @sm_udate, [sm_desc] = @sm_desc, [sm_isclose] = @sm_isclose
	WHERE  [sm_id] = @sm_id
	
	-- Begin Return Select <- do not remove
	SELECT [sm_id], [sm_bookno], [sm_refno], [sm_date], [led_id], [sm_totqty], [sm_totamount], [sm_itemcount], [sm_profit], [sm_disamount], [sm_packingcharge], [sm_netamount],sm_received,sm_paidcommission,sm_paidpacking,sm_iscommissionclose,sm_ispackingclose, [users_uid], [sm_udate], [sm_desc], [sm_isclose]
	FROM   [dbo].[salesmaster]
	WHERE  [sm_id] = @sm_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_salesmasterDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesmasterDelete] 
END 
GO
CREATE PROC [dbo].[usp_salesmasterDelete] 
    @sm_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[salesmaster]
	WHERE  [sm_id] = @sm_id

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_salesdetailsSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesdetailsSelect] 
END 
GO
CREATE PROC [dbo].[usp_salesdetailsSelect] 
    @sm_id BIGINT=null,
    @fdate DATE=NULL,
    @tdate DATE=NULL,
    @led_id BIGINT=NULL,
    @item_id BIGINT=NULL,
    @cat_id BIGINT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [sd_id], sm.sm_id,sm.sm_refno,sm.sm_date,sm.sm_disamount,sm.sm_netamount,sm.sm_packingcharge,sm.sm_totamount,sm.sm_profit,sm.sm_totqty,lm.led_name,lm.led_address,lm.led_address1,lm.led_address2,ct.cat_id,ct.cat_name, im.item_id,im.item_code ,im.item_name ,im.item_purchaserate,im.item_costrate,item_mrp,im.item_specialrate,im.item_supersepecialrate,im.item_wholesalerate, [sd_qty], [sd_rate], [sd_costrate], [sd_totamount] 
	FROM   [dbo].[salesdetails] sd
	join salesmaster    sm on sd.sm_id   =sm.sm_id  
	join ledgermaster   lm on sm.led_id =lm .led_id 
	join item   im on sd.item_id  =im.item_id 
	join category ct on ct.cat_id=im.cat_id
	WHERE  (sd.[sm_id] = @sm_id OR @sm_id IS NULL) 
	AND (lm.[led_id] = @led_id OR @led_id =0 OR @led_id IS NULL )
	AND (sd.item_id = @item_id OR @item_id =0 OR @item_id IS NULL)
	AND (im.cat_id = @cat_id OR @cat_id =0 OR @cat_id  IS NULL)
	AND (sm.[sm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	
	order by sm_id desc 
	
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_salesdetailsInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesdetailsInsert] 
END 
GO
CREATE PROC [dbo].[usp_salesdetailsInsert] 
    @sm_id BIGINT,
    @item_id BIGINT,
    @sd_qty decimal(18, 3),
    @sd_rate decimal(18, 3),
    @sd_costrate decimal(18, 3),
    @sd_totamount decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[salesdetails] ([sm_id], [item_id], [sd_qty], [sd_rate], [sd_costrate], [sd_totamount])
	SELECT @sm_id, @item_id, @sd_qty, @sd_rate, @sd_costrate, @sd_totamount
	
	-- Begin Return Select <- do not remove
	SELECT [sd_id], [sm_id], [item_id], [sd_qty], [sd_rate], [sd_costrate], [sd_totamount]
	FROM   [dbo].[salesdetails]
	WHERE  [sd_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_salesdetailsUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesdetailsUpdate] 
END 
GO
CREATE PROC [dbo].[usp_salesdetailsUpdate] 
    @sd_id BIGINT,
    @sm_id BIGINT,
    @item_id BIGINT,
    @sd_qty decimal(18, 3),
    @sd_rate decimal(18, 3),
    @sd_costrate decimal(18, 3),
    @sd_totamount decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[salesdetails]
	SET    [sm_id] = @sm_id, [item_id] = @item_id, [sd_qty] = @sd_qty, [sd_rate] = @sd_rate, [sd_costrate] = @sd_costrate, [sd_totamount] = @sd_totamount
	WHERE  [sd_id] = @sd_id
	
	-- Begin Return Select <- do not remove
	SELECT [sd_id], [sm_id], [item_id], [sd_qty], [sd_rate], [sd_costrate], [sd_totamount]
	FROM   [dbo].[salesdetails]
	WHERE  [sd_id] = @sd_id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_salesdetailsDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesdetailsDelete] 
END 
GO
CREATE PROC [dbo].[usp_salesdetailsDelete] 
    @sm_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[salesdetails]
	WHERE  ([sm_id] = @sm_id )

	COMMIT
GO

IF OBJECT_ID('[dbo].[usp_receiptSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_receiptSelect] 
END 
GO
CREATE PROC [dbo].[usp_receiptSelect] 
    @id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT re.[id],lm.led_name,led_address2, re.[rec_no], [rec_date], re.[led_id], re.[sm_id], re.[com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose] 
	FROM   [dbo].[receipt] re
	join salesmaster sm on sm.sm_id=re.sm_id
	join ledgermaster lm on lm.led_id=sm.led_id
	WHERE  ([id] = @id OR @id IS NULL) 
	and (re.led_id=@led_id OR @led_id IS NULL or @led_id=0)
	AND (re.[rec_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by id desc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_receiptInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_receiptInsert] 
END 
GO
CREATE PROC [dbo].[usp_receiptInsert] 
    @rec_no BIGINT,
    @rec_date datetime = NULL,
    @led_id BIGINT = NULL,
    @sm_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @rec_billamt decimal(12, 2),
    @rec_receivedamt decimal(12, 2),
    @rec_newbalance decimal(12, 2),
    @rec_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[receipt] ([rec_no], [rec_date], [led_id], [sm_id], [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose])
	SELECT @rec_no, @rec_date, @led_id, @sm_id, @com_id, @rec_billamt, @rec_receivedamt, @rec_newbalance, @rec_isclose
	
	update salesmaster set sm_received=sm_received+@rec_receivedamt,sm_isclose=@rec_isclose where sm_id=@sm_id
	-- Begin Return Select <- do not remove
	SELECT [id], [rec_no], [rec_date], [led_id], [sm_id], [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose]
	FROM   [dbo].[receipt]
	WHERE  [id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_receiptUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_receiptUpdate] 
END 
GO
CREATE PROC [dbo].[usp_receiptUpdate] 
    @id BIGINT,
    @rec_no BIGINT,
    @rec_date datetime = NULL,
    @led_id BIGINT = NULL,
    @sm_id BIGINT = NULL,
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
	SET    [rec_no] = @rec_no, [rec_date] = @rec_date, [led_id] = @led_id, [sm_id] = @sm_id, [com_id] = @com_id, [rec_billamt] = @rec_billamt, [rec_receivedamt] = @rec_receivedamt, [rec_newbalance] = @rec_newbalance, [rec_isclose] = @rec_isclose
	WHERE  [id] = @id
	
	-- Begin Return Select <- do not remove
	SELECT [id], [rec_no], [rec_date], [led_id], [sm_id], [com_id], [rec_billamt], [rec_receivedamt], [rec_newbalance], [rec_isclose]
	FROM   [dbo].[receipt]
	WHERE  [id] = @id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_receiptDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_receiptDelete] 
END 
GO
CREATE PROC [dbo].[usp_receiptDelete] 
    @id BIGINT,
    @sm_id BIGINT,
    @receivedamt decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	update salesmaster set sm_received=sm_received-@receivedamt,sm_isclose=0 where sm_id=@sm_id
	DELETE
	FROM   [dbo].[receipt]
	WHERE  [id] = @id

	COMMIT
GO
BEGIN TRAN


IF OBJECT_ID('[dbo].[usp_commissionreceiptSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_commissionreceiptSelect] 
END 
GO
CREATE PROC [dbo].[usp_commissionreceiptSelect] 
    @id BIGINT=null,
    @led_agid BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT re.[id],ag.led_name,ag.led_address2, re.[cr_no], [cr_date], re.[led_agid], re.[sm_id], re.[com_id], [cr_billamt], [cr_receivedamt], [cr_newbalance], [cr_isclose] 
	FROM   [dbo].[commissionreceipt] re
	join salesmaster sm on sm.sm_id=re.sm_id
	join ledgermaster lm on lm.led_id=sm.led_id
	join ledgermaster ag on ag.led_id=lm.led_id
	WHERE  ([id] = @id OR @id IS NULL) 
	and (ag.led_id=@led_agid OR @led_agid IS NULL or @led_agid=0)
	AND (re.[cr_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by id desc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_commissionreceiptInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_commissionreceiptInsert] 
END 
GO
CREATE PROC [dbo].[usp_commissionreceiptInsert] 
    @cr_no BIGINT,
    @cr_date datetime = NULL,
    @led_agid BIGINT = NULL,
    @sm_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @cr_billamt decimal(12, 2),
    @cr_receivedamt decimal(12, 2),
    @cr_newbalance decimal(12, 2),
    @cr_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[commissionreceipt] ([cr_no], [cr_date], [led_agid], [sm_id], [com_id], [cr_billamt], [cr_receivedamt], [cr_newbalance], [cr_isclose])
	SELECT @cr_no, @cr_date, @led_agid, @sm_id, @com_id, @cr_billamt, @cr_receivedamt, @cr_newbalance, @cr_isclose
	
	update salesmaster set sm_paidcommission =sm_paidcommission+@cr_receivedamt,sm_iscommissionclose=@cr_isclose where sm_id=@sm_id
	-- Begin Return Select <- do not remove
	SELECT [id], [cr_no], [cr_date], [led_agid], [sm_id], [com_id], [cr_billamt], [cr_receivedamt], [cr_newbalance], [cr_isclose]
	FROM   [dbo].[commissionreceipt]
	WHERE  [id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_commissionreceiptUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_commissionreceiptUpdate] 
END 
GO
CREATE PROC [dbo].[usp_commissionreceiptUpdate] 
    @id BIGINT,
    @cr_no BIGINT,
    @cr_date datetime = NULL,
    @led_agid BIGINT = NULL,
    @sm_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @cr_billamt decimal(12, 2),
    @cr_receivedamt decimal(12, 2),
    @cr_newbalance decimal(12, 2),
    @cr_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[commissionreceipt]
	SET    [cr_no] = @cr_no, [cr_date] = @cr_date, [led_agid] = @led_agid, [sm_id] = @sm_id, [com_id] = @com_id, [cr_billamt] = @cr_billamt, [cr_receivedamt] = @cr_receivedamt, [cr_newbalance] = @cr_newbalance, [cr_isclose] = @cr_isclose
	WHERE  [id] = @id
	
	-- Begin Return Select <- do not remove
	SELECT [id], [cr_no], [cr_date], [led_agid], [sm_id], [com_id], [cr_billamt], [cr_receivedamt], [cr_newbalance], [cr_isclose]
	FROM   [dbo].[commissionreceipt]
	WHERE  [id] = @id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_commissionreceiptDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_commissionreceiptDelete] 
END 
GO
CREATE PROC [dbo].[usp_commissionreceiptDelete] 
    @id BIGINT,
    @sm_id BIGINT,
    @receivedamt decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	update salesmaster set sm_paidcommission=sm_paidcommission-@receivedamt,sm_iscommissionclose=0 where sm_id=@sm_id
	DELETE
	FROM   [dbo].[commissionreceipt]
	WHERE  [id] = @id

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_packingreceiptSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_packingreceiptSelect] 
END 
GO
CREATE PROC [dbo].[usp_packingreceiptSelect] 
    @id BIGINT=null,
    @led_agid BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT re.[id],ag.led_name,ag.led_address2, re.[pr_no], [pr_date], re.[led_agid], re.[sm_id], re.[com_id], [pr_billamt], [pr_receivedamt], [pr_newbalance], [pr_isclose] 
	FROM   [dbo].[packingreceipt] re
	join salesmaster sm on sm.sm_id=re.sm_id
	join ledgermaster lm on lm.led_id=sm.led_id
	join ledgermaster ag on ag.led_id=lm.led_id
	WHERE  ([id] = @id OR @id IS NULL) 
	and (ag.led_id=@led_agid OR @led_agid IS NULL or @led_agid=0)
	AND (re.[pr_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by id desc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_packingreceiptInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_packingreceiptInsert] 
END 
GO
CREATE PROC [dbo].[usp_packingreceiptInsert] 
    @pr_no BIGINT,
    @pr_date datetime = NULL,
    @led_agid BIGINT = NULL,
    @sm_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @pr_billamt decimal(12, 2),
    @pr_receivedamt decimal(12, 2),
    @pr_newbalance decimal(12, 2),
    @pr_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[packingreceipt] ([pr_no], [pr_date], [led_agid], [sm_id], [com_id], [pr_billamt], [pr_receivedamt], [pr_newbalance], [pr_isclose])
	SELECT @pr_no, @pr_date, @led_agid, @sm_id, @com_id, @pr_billamt, @pr_receivedamt, @pr_newbalance, @pr_isclose
	
	update salesmaster set sm_paidpacking =sm_paidpacking+@pr_receivedamt,sm_ispackingclose=@pr_isclose where sm_id=@sm_id
	-- Begin Return Select <- do not remove
	SELECT [id], [pr_no], [pr_date], [led_agid], [sm_id], [com_id], [pr_billamt], [pr_receivedamt], [pr_newbalance], [pr_isclose]
	FROM   [dbo].[packingreceipt]
	WHERE  [id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_packingreceiptUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_packingreceiptUpdate] 
END 
GO
CREATE PROC [dbo].[usp_packingreceiptUpdate] 
    @id BIGINT,
    @pr_no BIGINT,
    @pr_date datetime = NULL,
    @led_agid BIGINT = NULL,
    @sm_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @pr_billamt decimal(12, 2),
    @pr_receivedamt decimal(12, 2),
    @pr_newbalance decimal(12, 2),
    @pr_isclose bit = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[packingreceipt]
	SET    [pr_no] = @pr_no, [pr_date] = @pr_date, [led_agid] = @led_agid, [sm_id] = @sm_id, [com_id] = @com_id, [pr_billamt] = @pr_billamt, [pr_receivedamt] = @pr_receivedamt, [pr_newbalance] = @pr_newbalance, [pr_isclose] = @pr_isclose
	WHERE  [id] = @id
	
	-- Begin Return Select <- do not remove
	SELECT [id], [pr_no], [pr_date], [led_agid], [sm_id], [com_id], [pr_billamt], [pr_receivedamt], [pr_newbalance], [pr_isclose]
	FROM   [dbo].[packingreceipt]
	WHERE  [id] = @id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_packingreceiptDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_packingreceiptDelete] 
END 
GO
CREATE PROC [dbo].[usp_packingreceiptDelete] 
    @id BIGINT,
    @sm_id BIGINT,
    @receivedamt decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	update salesmaster set sm_paidpacking=sm_paidpacking-@receivedamt,sm_ispackingclose=0 where sm_id=@sm_id
	DELETE
	FROM   [dbo].[packingreceipt]
	WHERE  [id] = @id

	COMMIT
GO





--IF OBJECT_ID('[dbo].[usp_OutstandingReport]') IS NOT NULL
--BEGIN 
--    DROP PROC [dbo].[usp_OutstandingReport] 
--END 
--GO
--CREATE PROC [dbo].[usp_OutstandingReport] 
--    @sm_id BIGINT=null,
--    @led_id BIGINT =null,
--    @fdate DATE=NULL,
--    @tdate DATE=NULL
    
--AS 
--	SET NOCOUNT ON 
--	SET XACT_ABORT ON  

--	BEGIN TRAN
--Select * from(
--	select  sup.[led_id],
--	sup.agid, 
--	sup.[sm_id],  
--	sup.billamt, rec_no,
--	isnull (rec_date,sm_date) as recdate,
--	isnull(DATEDIFF(DAY, sm.sm_date, rec_date),
--	DATEDIFF(DAY,sm.sm_date, GETDATE())) as dayscount,
--	isnull(recamt,0) recamt,
--	isnull(balanceamt,sup.billamt) balanceamt,
--	sm.sm_date,sm.sm_refno, [sm_isclose]  ,lm.led_name,led_address,lm.led_address1,lm.led_address2 
--	from (
-- 			SELECT sm.sm_id,lm.led_id,aglm.led_id as agid,re.rec_no,min(re.rec_date)as rec_date, SUM(rec_receivedamt) recamt,MAX(sm.sm_netamount) billamt,MAX(sm.sm_netamount)-SUM(rec_receivedamt) as balanceamt from receipt re 
--			right join salesmaster sm on sm.sm_id=re.sm_id
--			join ledgermaster lm on lm.led_id=sm.led_id	
--			join ledgermaster aglm on lm.led_agid=aglm.led_id	
--			group by sm.sm_id,lm.led_id,aglm.led_id,re.rec_date,re.rec_no
--		) as sup	
--		right join salesmaster sm on sm.sm_id=sup.sm_id
--		join ledgermaster lm on lm.led_id=sm.led_id	
--	) as q 	
--	WHERE  (q.[sm_id]  = @sm_id OR @sm_id IS NULL) 
--	and (q.agid=@led_id OR @led_id IS NULL or @led_id=0)	
--	AND q.balanceamt>0
--	order by q.recdate asc
--	COMMIT
--GO

IF OBJECT_ID('[dbo].[usp_OutstandingReport]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_OutstandingReport] 
END 
GO
CREATE PROC [dbo].[usp_OutstandingReport] 
    @sm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN	
	SELECT sm.sm_id,lm.led_id,aglm.led_id as agid,DATEDIFF(DAY,sm.sm_date, GETDATE()) as dayscount,[sm_isclose]  ,lm.led_name,lm.led_address,lm.led_address1,lm.led_address2 ,sm.sm_date,sm.sm_refno,sm.sm_netamount billamt,sm_received,sm.sm_netamount-sm_received as balanceamt from 
	salesmaster sm 
	join ledgermaster lm on lm.led_id=sm.led_id	
	join ledgermaster aglm on lm.led_agid=aglm.led_id						
	WHERE  (sm.[sm_id]  = @sm_id OR @sm_id IS NULL) 
	and (aglm.led_id =@led_id OR @led_id IS NULL or @led_id=0)	
	AND (sm.sm_netamount-sm_received)>0
	order by sm.sm_date asc
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_LedgerwiseOutstandingReport]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_LedgerwiseOutstandingReport] 
END 
GO
CREATE PROC [dbo].[usp_LedgerwiseOutstandingReport] 
     @sm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
Select * from(
	select  sup.[led_id],
	sup.agid, 
	sup.[sm_id],  
	sup.billamt,rec_id, rec_no,
	isnull (rec_date,sm_date) as recdate,
	isnull(DATEDIFF(DAY, sm.sm_date, rec_date),
	DATEDIFF(DAY,sm.sm_date, GETDATE())) as dayscount,
	isnull(recamt,0) recamt,
	isnull(balanceamt,sup.billamt) balanceamt,
	 CASE WHEN  sm_received=0
	  THEN billamt 
	  WHEN  balanceamt+recamt=billamt  then billamt
	   else 0 end as netamt,
	sm.sm_date,sm.sm_refno, [sm_isclose]  ,lm.led_name,led_address,lm.led_address1,lm.led_address2 
	from (
 			SELECT re.id rec_id,sm.sm_id,lm.led_id,aglm.led_id as agid,re.rec_no,min(re.rec_date)as rec_date, SUM(rec_receivedamt) recamt, MAX(sm.sm_netamount) billamt,MIN(re.rec_newbalance) as balanceamt from receipt re 
			right join salesmaster sm on sm.sm_id=re.sm_id
			join ledgermaster lm on lm.led_id=sm.led_id	
			join ledgermaster aglm on lm.led_agid=aglm.led_id	
			group by sm.sm_id,lm.led_id,aglm.led_id,re.rec_date,re.rec_no,re.id
		) as sup	
		right join salesmaster sm on sm.sm_id=sup.sm_id
		join ledgermaster lm on lm.led_id=sm.led_id	
	) as q 	
	WHERE  (q.[sm_id]  = @sm_id OR @sm_id IS NULL) 
	and (q.[led_id]=@led_id OR @led_id IS NULL or @led_id=0)	
	--AND (q.sm_date  BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)	
	--AND (q.recdate  BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)	
	AND q.balanceamt>0
	order by q.rec_id,q.sm_id asc
	COMMIT
GO

 
 
IF OBJECT_ID('[dbo].[usp_AgentComissionReport]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_AgentComissionReport] 
END 
GO
Create PROC [dbo].[usp_AgentComissionReport] 
    @agent_id BIGINT =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

 select sm.sm_refno as BillNo,sm_date as BillDate,lm.led_id,lm.led_agid,lm.led_name as CustomerName,ag.led_name as Agent,
 lm.led_address2 as City,lm.led_ownername as OwnerName,lm.led_ownerphone as OwnerPhone,lm.led_tin ,lm.led_cst ,sm.sm_profit as Profit from salesmaster sm
 join ledgermaster lm on lm.led_id =sm.led_id 
 join ledgermaster ag on ag.led_id=lm.led_agid
  where ag.led_accounttype='Agent'
    AND (lm.led_agid=@agent_id OR @agent_id=0 OR @agent_id is null)
	AND (sm.[sm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)	
	order by sm_date desc
	COMMIT

GO

 
IF OBJECT_ID('[dbo].[usp_ledgerItemDetailsReport]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ledgerItemDetailsReport] 
END 
GO
CREATE PROC [dbo].[usp_ledgerItemDetailsReport] 
    @ItemId BIGINT=null,
    @CatId BIGINT=null,
    @ItemName  nvarchar(100) =null,
    @fdate DATE=NULL,
    @tdate DATE=NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN


select ItemId,ItemName,cat_name,billno,BillDate,[Type],PartyName,led_address2 as City,PQty,SQty from(

select i.item_id as ItemId,i.item_name as ItemName,ct.cat_id,ct.cat_name,pm.pm_no as billno,pm.pm_date as BillDate ,'Purchase' as [Type],lm.led_name as PartyName,lm.led_address2,pd.pd_qty as PQty,0 as SQty
from purchasemaster pm
inner join purchasedetails pd on pm.pm_id =pd.pm_id 
inner join item i on pd.item_id =i.item_id  
inner join ledgermaster lm on pm.led_id =lm.led_id 
join category ct on ct.cat_id=i.cat_id
union ALL

select i.item_id as ItemId, i.item_name as ItemName,ct.cat_id,ct.cat_name,sm.sm_refno as billno,sm.sm_date as BillDate ,'Sales' as Type,lm.led_name as PartyName,lm.led_address2,0 as PQty,sd.sd_qty as SQty
from salesmaster sm
inner join salesdetails  sd on sm.sm_id =sd.sm_id 
inner join item i on sd.item_id =i.item_id  
join category ct on ct.cat_id=i.cat_id
inner join ledgermaster lm on sm.led_id =lm.led_id
 ) as itemdetails 
 
 where (ItemName like '%'+@ItemName  +'%' or @ItemName   IS NULL)
 AND (cat_id  = @CatId OR @CatId =0 OR  @CatId IS NULL)  
 AND (ItemId  = @ItemId OR @ItemId=0 OR @ItemId IS NULL)  
	AND (BillDate  BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)	
order by BillDate ,Type 

COMMIT

GO

IF OBJECT_ID('[dbo].[usp_stockSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockSelect] 
END 
GO
CREATE PROC [dbo].[usp_stockSelect] 
    @item_id BIGINT=null,
    @refid BIGINT=null,
    @stockfrom nvarchar(10)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT  [item_id], sum([stock_addqty]) as AddQty, sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as stock
	FROM   [dbo].[stock] 
	WHERE  (item_id = @item_id OR @item_id IS NULL) 
	AND ([refid] = @refid OR @refid IS NULL) 
	AND (stockfrom = @stockfrom OR @stockfrom IS NULL) 
	group by item_id

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_GetItemList]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_GetItemList] 
END 
GO
CREATE PROC [dbo].[usp_GetItemList] 
    @item_id BIGINT=null,
    @cat_id BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
	
	
	select stk.item_id,stk.AddQty,stk.LessQty,stk.stock,i.item_name,i.item_costrate,i.item_mrp,i.item_purchaserate,i.item_specialrate,i.item_supersepecialrate,
	i.item_wholesalerate, * from (
	SELECT  [item_id], sum([stock_addqty]) as AddQty,
	 sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as stock
	FROM   [dbo].[stock] 
	group by item_id )as stk
	join item i on i.item_id=stk.item_id
	where (i.cat_id=@cat_id or @cat_id is null)
	and (i.item_id = @item_id OR @item_id IS NULL)
	order by i.item_id ASC
	
	COMMIT
GO

IF OBJECT_ID('[dbo].[usp_stockReport]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockReport] 
END 
GO
CREATE PROC [dbo].[usp_stockReport] 
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
	COMMIT
GO

IF OBJECT_ID('[dbo].[usp_stockInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockInsert] 
END 
GO
CREATE PROC [dbo].[usp_stockInsert] 
    @refid BIGINT,
    @stockfrom nvarchar(10),
    @item_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @stock_addqty decimal(12, 2),
    @stock_lessqty decimal(12, 2),
    @stock_date datetime = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[stock] ([refid], [stockfrom], [item_id], [com_id], [stock_addqty], [stock_lessqty], [stock_date])
	SELECT @refid, @stockfrom, @item_id, @com_id, @stock_addqty, @stock_lessqty, @stock_date
	
	-- Begin Return Select <- do not remove
	SELECT [id], [refid], [stockfrom], [item_id], [com_id], [stock_addqty], [stock_lessqty], [stock_date]
	FROM   [dbo].[stock]
	WHERE  [id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_stockUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockUpdate] 
END 
GO
CREATE PROC [dbo].[usp_stockUpdate] 
    @id BIGINT,
    @refid BIGINT,
    @stockfrom nvarchar(10),
    @item_id BIGINT = NULL,
    @com_id BIGINT = NULL,
    @stock_addqty decimal(12, 2),
    @stock_lessqty decimal(12, 2),
    @stock_date datetime = NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[stock]
	SET    [refid] = @refid, [stockfrom] = @stockfrom, [item_id] = @item_id, [com_id] = @com_id, [stock_addqty] = @stock_addqty, [stock_lessqty] = @stock_lessqty, [stock_date] = @stock_date
	WHERE  [id] = @id
	
	-- Begin Return Select <- do not remove
	SELECT [id], [refid], [stockfrom], [item_id], [com_id], [stock_addqty], [stock_lessqty], [stock_date]
	FROM   [dbo].[stock]
	WHERE  [id] = @id	
	-- End Return Select <- do not remove

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_stockDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockDelete] 
END 
GO
CREATE PROC [dbo].[usp_stockDelete] 
    @id BIGINT,
    @stockfrom nvarchar(10)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[stock]
	WHERE  [refid] = @id and stockfrom=@stockfrom

	COMMIT
GO


IF OBJECT_ID('[dbo].[usp_getYearNo]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].usp_getYearNo 
END 
GO
create procedure usp_getYearNo
	@field nvarchar(50)=null,
	@curdate datetime=null,
	@no BIGINT OUTPUT
as
declare @SD datetime
declare @ED datetime
begin

	if(select count(*) from yearly where @curDate between year_fdate and year_tdate and @field=year_field) = 0
	begin
	if datepart(month,@curdate)>=1 and datepart(month,@curdate) <= 3
	begin
	set @SD = '1-Apr-'+cast(datepart(yy,@curdate)-1 as nvarchar)
	set @ED = '31-Mar-'+cast(datepart(yy,@curdate) as nvarchar)
	end
	else
	begin
	set @SD = '1-Apr-'+cast(datepart(yy,@curdate) as nvarchar)
	set @ED = '31-Mar-'+cast(datepart(yy,@curdate)+1 as nvarchar)
	end
	insert INTO yearly(year_fdate,year_tdate,year_field) values(@SD,@ED,@field);
	end

	select @no=isnull(year_value,0)+1 from yearly where @curdate between year_fdate and year_tdate and @field=year_field;
end
GO
IF OBJECT_ID('[dbo].[usp_setYearNo]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].usp_setYearNo 
END 
GO
create procedure usp_setYearNo
	@field nvarchar(50)=null,
	@curdate datetime=null,
	@no BIGINT OUTPUT
as
declare @SD datetime
declare @ED datetime
begin

	if(select count(*) from yearly where @curdate between year_fdate and year_tdate and @field=year_field) = 0
	begin
	if datepart(month,@curdate)>=1 and datepart(month,@curdate) <= 3
	begin
	set @SD = '1-Apr-'+cast(datepart(yy,@curdate)-1 as nvarchar)
	set @ED = '31-Mar-'+cast(datepart(yy,@curdate) as nvarchar)
	end
	else
	begin
	set @SD = '1-Apr-'+cast(datepart(yy,@curdate) as nvarchar)
	set @ED = '31-Mar-'+cast(datepart(yy,@curdate)+1 as nvarchar)
	end
	insert INTO yearly(year_fdate,year_tdate,year_field)
	values(@SD,@ED,@field)
	end
	select @no=isnull(year_value,0)+1 from yearly where @curdate between year_fdate and year_tdate and @field=year_field
	update yearly set year_value=isnull(year_value,0)+1 where @curdate between year_fdate and year_tdate and @field=year_field
	
end
GO


IF OBJECT_ID('[dbo].[usp_settingsSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_settingsSelect] 
END 
GO
CREATE PROC [dbo].[usp_settingsSelect] 
    @sett_name NVARCHAR(25)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [sett_name], [sett_str], [sett_num], [sett_date]
	FROM   [dbo].[settings] 
	WHERE  ([sett_name] = @sett_name OR @sett_name IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_settingsUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_settingsUpdate] 
END 
GO
CREATE PROC [dbo].[usp_settingsUpdate] 
    @sett_name nvarchar(25),
    @sett_str nvarchar(300),
    @sett_num BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[settings]
	SET    [sett_name] = @sett_name, [sett_str] = @sett_str, [sett_num] = @sett_num
	WHERE  [sett_name] = @sett_name

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_backup]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].usp_backup
END
GO
CREATE PROC [dbo].[usp_backup]
	@dbname nvarchar(20)
AS
	declare @backdate datetime;
	declare @location nvarchar(200);
	SET NOCOUNT ON
	SET XACT_ABORT ON
	
	set @backdate = (select sett_date from settings where sett_name='backloc');
	set @location = isnull((select sett_str from settings where sett_name='backloc'),'');
	
	if(datediff(day,@backdate,getdate()) > 0 and @location<>'')
	BEGIN
	
	SET @location = @location + '\' + @dbname  + CONVERT(nvarchar,GETDATE(),105) + '.bak';
	
	BACKUP DATABASE @dbname TO DISK = @location WITH  INIT ,  NOUNLOAD ,  NAME = @dbname,  NOSKIP ,  STATS = 10, NOFORMAT;
	
	update settings set sett_date=getdate() where sett_name='backloc';

	END
GO


IF OBJECT_ID('[dbo].[usp_mailSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_mailSelect] 
END 
GO
CREATE PROC [dbo].[usp_mailSelect] 
    @mail_server NVARCHAR(100),
    @mail_from NVARCHAR(200)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [mail_server], [mail_from], [mail_uid], [mail_pwd], [mail_port], [mail_to], [mail_ssl], [mail_dpath] 
	FROM   [dbo].[mail] 
	WHERE  ([mail_server] = @mail_server OR @mail_server IS NULL) 
	       AND ([mail_from] = @mail_from OR @mail_from IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_mailInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_mailInsert] 
END 
GO
CREATE PROC [dbo].[usp_mailInsert] 
    @mail_server nvarchar(100),
    @mail_from nvarchar(200),
    @mail_uid nvarchar(100),
    @mail_pwd nvarchar(100),
    @mail_port BIGINT,
    @mail_to nvarchar(100),
    @mail_ssl char(1),
    @mail_dpath nvarchar(500)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	DELETE	FROM   [dbo].[mail];
	
	INSERT INTO [dbo].[mail] ([mail_server], [mail_from], [mail_uid], [mail_pwd], [mail_port], [mail_to], [mail_ssl], [mail_dpath])
	SELECT @mail_server, @mail_from, @mail_uid, @mail_pwd, @mail_port, @mail_to, @mail_ssl, @mail_dpath
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_ResetTransaction]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_ResetTransaction] 
END 
GO
CREATE PROC [dbo].[usp_ResetTransaction] 
  
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN 

Truncate table Stock

delete from receipt
delete from SalesDetails
delete from SalesMaster
delete from PurchaseDetails
delete from PurchaseMaster
delete from Yearly

end


--IF OBJECT_ID('[dbo].[usp_stockreport]') IS NOT NULL
--BEGIN 
--    DROP PROC [dbo].[usp_stockreport]
--END 
--GO
--CREATE PROC [dbo].[usp_stockreport]
--    @RptType NVARCHAR(20)=NULL,  
--    @item_id BIGINT=NULL,
--    @date DATETIME=null
--AS 
--	SET NOCOUNT ON 
--	SET XACT_ABORT ON  

--	BEGIN TRAN
	
--	IF(@RptType = 'ITEM STOCK')
--	BEGIN

		
--	END
--	ELSE IF(@RptType = 'PURCAHSE STOCK')
--	BEGIN
	
		
		
--	END
	
--	COMMIT TRAN
--GO

--DEFAULT VALUES

--new changes 30-04-2017
GO

IF OBJECT_ID('[dbo].[usp_GetItemList]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_GetItemList] 
END 
GO
CREATE PROC [dbo].[usp_GetItemList] 
    @item_id BIGINT=null,
    @cat_id BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
	
	
	select i.item_id,isnull(stk.AddQty,0) as AddQty,isnull(stk.LessQty,0)as LessQty,isnull(stk.stock,0) as stock,i.item_name,i.item_costrate,i.item_mrp,i.item_purchaserate,i.item_specialrate,i.item_supersepecialrate,
	i.item_wholesalerate from 
	(
	SELECT  i.[item_id], sum([stock_addqty]) as AddQty,
	 sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as stock
	FROM   [dbo].[stock] s
	left join item i on i.item_id=s.item_id
	group by i.item_id )as stk
	right join item i on i.item_id=stk.item_id 
	where (i.cat_id=@cat_id or @cat_id is null)
	and (i.item_id = @item_id OR @item_id IS NULL)
	order by item_id asc
	COMMIT
GO