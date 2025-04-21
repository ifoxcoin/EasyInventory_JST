CREATE DATABASE dstore
GO
USE dstore
GO
/*users*/
IF OBJECT_ID('[dbo].[users]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].users 
END 
GO
create table users
(
	users_uid int identity primary key not null,
	users_name nvarchar(25) unique default(''),
	users_pwd nvarchar(50) default(''),
	users_date datetime default (getdate()),
	users_pid int default 0,
	users_type char(1) default(''),
	users_lock char(1) default('N')
)
GO
insert into users(users_name,users_pwd,users_pid,users_type) values('ADMIN','p55HM/Xq3BUOmUIvTjCBlg==',0,'A')
GO
IF OBJECT_ID('[dbo].[usp_usersSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_usersSelect] 
END 
GO
CREATE PROC [dbo].[usp_usersSelect] 
    @users_uid INT=NULL
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
    @users_pid int,
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
    @users_uid int,
    @users_name nvarchar(25),
    @users_pwd nvarchar(50),
    @users_pid int,
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
    @users_uid int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[users]
	WHERE  [users_uid] = @users_uid

	COMMIT
GO
/*module*/
IF OBJECT_ID('[dbo].[module]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].module
END
GO
create table module
( 
	modulecode int NOT NULL primary key,
	modulename nvarchar(50)
)
GO
/*form*/
IF OBJECT_ID('[dbo].[form]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].form
END
GO
create table form 
(	
	formcode int primary key,
	modulecode int foreign key references module(modulecode),
	formname nvarchar(50),
	A char(1) default('N'),
	E char(1) default('N'),
	D char(1) default('N'),
	V char(1) default('N'),
	P char(1) default('N')
)
GO
/*rights*/
IF OBJECT_ID('[dbo].[rights]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].rights
END
GO
create table rights
(
	formcode int foreign key references form(formcode),
	ucode int,
	A Char(1) Default('N'),
	E Char(1) Default('N'),
	D Char(1)Default('N'),
	V Char(1) Default('N'),
	P Char(1) Default('N')
)
GO
IF OBJECT_ID('[dbo].[usp_rightsInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_rightsInsert]
END 
GO
create proc usp_rightsInsert
	@formcode Int=NULL,
	@ucode int=NULL,
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
	@ucode INT=NULL
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
    @rucode INT=null,
    @ucode INT=null
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
/*company*/
IF OBJECT_ID('[dbo].[company]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].company
END 
GO
create table company
(
	com_id int identity primary key,
	com_name nvarchar(100) unique not null,
	com_add1 nvarchar(50) default(''),
	com_add2 nvarchar(50) default(''),
	com_add3 nvarchar(50) default(''),
	com_city nvarchar(50) default(''),
	com_state nvarchar(50) default(''),
	com_country nvarchar(50) default(''),
	com_phone nvarchar(50) default(''),
	com_mobile1 nvarchar(15) default(''),
	com_mobile2 nvarchar(15) default(''),
	com_fax nvarchar(50) default(''),
	com_pin nvarchar(7) default(''),
	com_email nvarchar(50) default(''),
	com_web nvarchar(50) default(''),
	com_default char(1) default('N'),
	com_tin nvarchar(50) default(''),
	com_cst nvarchar(50) default(''),
	com_cstdate date default('01-Jan-1900'),
	com_pan nvarchar(50) default('')
)
GO
IF OBJECT_ID('[dbo].[usp_companySelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_companySelect] 
END 
GO
CREATE PROC [dbo].[usp_companySelect] 
    @com_id INT
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
    @com_id int,
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
    @com_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[company]
	WHERE  [com_id] = @com_id

	COMMIT
GO
exec usp_companyInsert 'BLUEWINGS TECHNOLOGIES','ADDRESS 1','ADDRESS 2','ADDRESS 3','CITY','TAMIL NADU','COUNTRY','000-00000','','','','','','','Y','','','01-Jan-1900','';
GO
/*item*/
IF OBJECT_ID('[dbo].[item]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].item
END 
GO
create table item
(
	item_id int identity primary key,
	item_name nvarchar(50) unique not null,
	item_tamil nvarchar(100) unique,
	item_taen nvarchar(100),
	users_uid int foreign key references users(users_uid),
	item_date datetime
)
GO
IF OBJECT_ID('[dbo].[usp_itemSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemSelect] 
END 
GO
CREATE PROC [dbo].[usp_itemSelect] 
    @item_id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [item_id], [item_name], [item_tamil], [item_taen], [users_uid], [item_date] 
	FROM   [dbo].[item] 
	WHERE  ([item_id] = @item_id OR @item_id IS NULL) 
	ORDER BY [item_name]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_itemInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemInsert] 
END 
GO
CREATE PROC [dbo].[usp_itemInsert] 	
    @item_name nvarchar(50),
    @item_tamil nvarchar(100),
    @item_taen nvarchar(100),
    @users_uid int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[item] ([item_name], [item_tamil], [item_taen], [users_uid], [item_date])
	SELECT @item_name, @item_tamil, @item_taen, @users_uid, GETDATE()

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_itemUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemUpdate] 
END 
GO
CREATE PROC [dbo].[usp_itemUpdate] 
    @item_id int,
    @item_name nvarchar(50),
    @item_tamil nvarchar(100),
    @item_taen nvarchar(100),
    @users_uid int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[item]
	SET    [item_name] = @item_name, [item_tamil] = @item_tamil, [item_taen] = @item_taen, [users_uid] = @users_uid, [item_date] = GETDATE()
	WHERE  [item_id] = @item_id

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_itemDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_itemDelete] 
END 
GO
CREATE PROC [dbo].[usp_itemDelete] 
    @item_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[item]
	WHERE  [item_id] = @item_id

	COMMIT
GO
/*tax*/
IF OBJECT_ID('[dbo].[tax]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].tax
END 
GO
CREATE TABLE dbo.tax
(
	tax_id int identity primary key,
	tax_name nvarchar(20) unique not null,
	tax_ptax decimal(5, 2) default(0),
	tax_stax decimal(5, 2) default(0),
	users_uid int foreign key references users(users_uid),
	tax_udate datetime default(getdate())
)
GO
IF OBJECT_ID('[dbo].[usp_taxSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_taxSelect] 
END 
GO
CREATE PROC [dbo].[usp_taxSelect] 
    @tax_id INT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [tax_id], [tax_name], [tax_ptax], [tax_stax], [users_uid], [tax_udate]
	FROM   [dbo].[tax] 
	WHERE  ([tax_id] = @tax_id OR @tax_id IS NULL) and [tax_id]<>0
	ORDER BY [tax_name]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_taxInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_taxInsert] 
END 
GO
CREATE PROC [dbo].[usp_taxInsert] 
    @tax_name nvarchar(20),
    @tax_ptax decimal(5, 2),
    @tax_stax decimal(5, 2),
    @users_uid int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[tax] ([tax_name], [tax_ptax], [tax_stax], [users_uid], [tax_udate])
	SELECT @tax_name, @tax_ptax, @tax_stax, @users_uid, GETDATE()
	
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_taxUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_taxUpdate] 
END 
GO
CREATE PROC [dbo].[usp_taxUpdate] 
    @tax_id int,
    @tax_name nvarchar(20),
    @tax_ptax decimal(5, 2),
    @tax_stax decimal(5, 2),
    @users_uid int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[tax]
	SET    [tax_name] = @tax_name, [tax_ptax] = @tax_ptax, [tax_stax] = @tax_stax, [users_uid] = @users_uid, [tax_udate] = GETDATE()
	WHERE  [tax_id] = @tax_id
	
	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_taxDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_taxDelete] 
END 
GO
CREATE PROC [dbo].[usp_taxDelete] 
    @tax_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[tax]
	WHERE  [tax_id] = @tax_id

	COMMIT
GO
/*accgroup*/
IF OBJECT_ID('[dbo].[accgroup]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].accgroup
END 
GO
create table accgroup
(
	ag_id int identity primary key not null,
	ag_name nvarchar(50) UNIQUE NOT NULL,
	ag_type nvarchar(15),
	ag_affect nvarchar(15),
	ag_dgroup char(1),
	users_uid int foreign key references users(users_uid),
	ag_udate dateTime  default(getdate()),
	ag_gunder int
)
GO
IF OBJECT_ID('[dbo].[usp_accgroupSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accgroupSelect] 
END 
GO
CREATE PROC [dbo].[usp_accgroupSelect] 
	@ag_id INT=null,
    @ag_name nvarchar(50)=null,
    @ag_gunder int=null
AS
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT a.[ag_id], a.[ag_name], a.[ag_type], a.[ag_affect], a.[ag_dgroup], a.[users_uid], a.[ag_udate], a.[ag_gunder], g.[ag_name] pag_name
	FROM [dbo].[accgroup] a
	LEFT JOIN [dbo].[accgroup] g on g.[ag_id]=a.[ag_gunder] 
	WHERE  (a.[ag_id] = @ag_id OR @ag_id IS NULL) and a.[ag_id]<>0
		AND (a.[ag_name] = @ag_name OR @ag_name IS NULL)
		AND (a.[ag_gunder] = @ag_gunder or @ag_gunder is null)
	ORDER BY a.[ag_name]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_accgroupInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accgroupInsert] 
END 
GO
CREATE PROC [dbo].[usp_accgroupInsert] 
    @ag_name nvarchar(50),
    @ag_type nvarchar(15),
    @ag_affect nvarchar(15),
    @ag_dgroup char(1),
    @users_uid int,
    @ag_gunder int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[accgroup] ([ag_name], [ag_type], [ag_affect], [ag_dgroup], [users_uid], [ag_udate], [ag_gunder])
	SELECT @ag_name, @ag_type, @ag_affect, @ag_dgroup, @users_uid, GETDATE(), @ag_gunder
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_accgroupUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accgroupUpdate] 
END 
GO
CREATE PROC [dbo].[usp_accgroupUpdate] 
    @ag_id int,
    @ag_name nvarchar(50),
    @ag_type nvarchar(15),
    @ag_affect nvarchar(15),
    @users_uid int,
    @ag_gunder int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[accgroup]
	SET    [ag_name] = @ag_name, [ag_type] = @ag_type, [ag_affect] = @ag_affect, [users_uid] = @users_uid, [ag_uDate] = GETDATE(), [ag_gunder] = @ag_gunder
	WHERE  [ag_id] = @ag_id and [ag_dgroup] = 'N'

	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_accgroupDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accgroupDelete] 
END 
GO
CREATE PROC [dbo].[usp_accgroupDelete] 
    @ag_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[accgroup]
	WHERE  [ag_id] = @ag_id and [ag_dgroup] = 'N'

	COMMIT
GO
exec usp_accgroupInsert 'Capital Account','LIABILITY','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Reserves and Surplus','LIABILITY','BALANCE SHEET','Y',1,1
GO
exec usp_accgroupInsert 'Current Assets','ASSET','BALANCE SHEET','Y',1,0
GO
exec usp_accgroupInsert 'Bank Account','ASSET','BALANCE SHEET','Y',1,3
GO
exec usp_accgroupInsert 'Cash In Hand','ASSET','BALANCE SHEET','Y',1,3
GO
exec usp_accgroupInsert 'Deposits','ASSET','BALANCE SHEET','Y',1,3
GO
exec usp_accgroupInsert 'Loans and Advances','ASSET','BALANCE SHEET','Y',1,3
GO
exec usp_accgroupInsert 'Stock In Hand','ASSET','BALANCE SHEET','Y',1,3
GO
exec usp_accgroupInsert 'Sundry Debtors','ASSET','BALANCE SHEET','Y',1,3
GO
exec usp_accgroupInsert 'Current Liabilities','LIABILITY','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Duties and Taxes','LIABILITY','PROFIT AND LOSE','Y',1,10
GO
exec usp_accgroupInsert 'Provisions','LIABILITY','PROFIT AND LOSE','Y',1,10
GO
exec usp_accgroupInsert 'Sundry Creditors','LIABILITY','PROFIT AND LOSE','Y',1,10
GO
exec usp_accgroupInsert 'Fixed Assets','ASSET','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Investments','ASSET','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Loans','LIABILITY','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Bank Overdraft','LIABILITY','PROFIT AND LOSE','Y',1,16
GO
exec usp_accgroupInsert 'Secured Loans','LIABILITY','PROFIT AND LOSE','Y',1,16
GO
exec usp_accgroupInsert 'Unsecured Loans','LIABILITY','PROFIT AND LOSE','Y',1,16
GO
exec usp_accgroupInsert 'Suspence Account','ASSET','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Miscellaneous Expenses','EXPENDITURE','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Branch/Divisions','LIABILITY','BALANCE SHEET','Y',1,0
GO
exec usp_accgroupInsert 'Direct Income','INCOME','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Indirect Income','INCOME','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Sales Account','INCOME','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Purchase Account','EXPENDITURE','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Direct Expenses','EXPENDITURE','PROFIT AND LOSE','Y',1,0
GO
exec usp_accgroupInsert 'Indirect Expenses','EXPENDITURE','PROFIT AND LOSE','Y',1,0
GO
/*accmaster*/
IF OBJECT_ID('[dbo].[accmaster]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].accmaster
END 
GO
create table accmaster
(
	am_id int identity primary key,
	am_name nvarchar(50) UNIQUE NOT NULL,
	am_shortname nvarchar(20) default(''),
	ag_id int foreign key references accgroup(ag_id),
	am_pid int default(0),
	am_add1 nvarchar(100) default(''),
	am_add2 nvarchar(100) default(''),
	am_city nvarchar(50) default(''),
	am_district nvarchar(50) default(''),
	am_state nvarchar(50) default(''),
	am_country nvarchar(50) default(''),
	am_pin nvarchar(10) default(''),
	am_stdcode nvarchar(10) default(''),
	am_phone nvarchar(15) default(''),
	am_mobile1 nvarchar(15) default(''),
	am_mobile2 nvarchar(15) default(''),
	am_climit decimal(12,2) default(0),
	am_mail nvarchar(50) default(''),
	users_uid int foreign key references users(users_uid),
	am_udate dateTime  default(getdate()),
	am_customer char(1) default('N'),
	am_default char(1) default('N'),
	am_tin nvarchar(50) default(''),
	am_cst nvarchar(50) default(''),
	am_lock  char(1) default('N'),
	am_acccode nvarchar(20) default(''),
	am_branch nvarchar(100) default(''),
	am_account nvarchar(50) default(''),
	am_bank nvarchar(100) default('')
)
GO
IF OBJECT_ID('[dbo].[usp_accmasterSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accmasterSelect] 
END 
GO
CREATE PROC [dbo].[usp_accmasterSelect] 
    @am_id INT=NULL,
    @am_lock char(1)=NULL
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRAN

	SELECT a.[am_id], a.[am_name], a.[am_shortname], g.[ag_name], pp.[am_name] refparty, a.[ag_id], a.[am_pid], a.[am_add1], a.[am_add2], a.[am_city], a.[am_state], a.[am_pin], a.[am_stdcode], a.[am_phone], a.[am_mobile1], a.[am_mobile2], a.[am_mail], a.[users_uid], a.[am_udate],a.am_customer, a.[am_default], a.[am_district], a.[am_tin], a.[am_cst], a.[am_climit], a.[am_lock], a.[am_country], a.[am_branch], a.[am_account], a.[am_bank], a.[am_acccode]
	FROM   [dbo].[accmaster] a
	JOIN [dbo].[accgroup] g on g.[ag_id]=a.[ag_id]
	LEFT JOIN [dbo].[accmaster] pp on pp.[am_id]=a.[am_pid]
	WHERE (a.am_lock<>'Y' or @am_lock='Y') AND a.[am_id]<>0 AND
	 (a.[am_id]=@am_id OR @am_id is null)
	ORDER BY a.[am_name]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_accmasterInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accmasterInsert] 
END 
GO
CREATE PROC [dbo].[usp_accmasterInsert] 
    @am_name nvarchar(50),
    @am_shortname nvarchar(20),
    @ag_id int,
    @am_pid int,
    @am_add1 nvarchar(100),
    @am_add2 nvarchar(100),
    @am_city nvarchar(100),
    @am_state nvarchar(50),
    @am_pin nvarchar(10),
    @am_stdcode nvarchar(10),
    @am_phone nvarchar(12),
    @am_mobile1 nvarchar(11),
    @am_mobile2 nvarchar(11),
    @am_mail nvarchar(100),
    @users_uid int,
    @am_customer char(1),
    @am_default char(1),
    @am_district nvarchar(50),
    @am_tin nvarchar(50),
    @am_cst nvarchar(50),
    @am_climit decimal(12, 2),
    @am_lock char(1),
    @am_acccode nvarchar(20),
    @am_country nvarchar(50),
    @am_branch nvarchar(100),
    @am_account nvarchar(50),
    @am_bank nvarchar(100)
AS
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[accmaster] ([am_name], [am_shortname], [ag_id], [am_pid], [am_add1], [am_add2], [am_city], [am_state], [am_pin], [am_stdcode], [am_phone], [am_mobile1], [am_mobile2], [am_mail], [users_uid], [am_udate],[am_customer], [am_default], [am_district], [am_tin], [am_cst], [am_climit], [am_lock], [am_country], [am_branch], [am_account], [am_bank], [am_acccode])
	SELECT @am_name, @am_shortname, @ag_id, @am_pid, @am_add1, @am_add2, @am_city, @am_state, @am_pin, @am_stdcode, @am_phone, @am_mobile1, @am_mobile2, @am_mail, @users_uid, GETDATE(),@am_customer, @am_default,@am_district, @am_tin, @am_cst, @am_climit, @am_lock, @am_country, @am_branch, @am_account, @am_bank, @am_acccode

	COMMIT
	
	RETURN @@IDENTITY;
GO
IF OBJECT_ID('[dbo].[usp_accmasterUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accmasterUpdate] 
END 
GO
CREATE PROC [dbo].[usp_accmasterUpdate]
    @am_id int,
    @am_name nvarchar(50),
    @am_shortname nvarchar(20),
    @ag_id int,
    @am_pid int,
    @am_add1 nvarchar(100),
    @am_add2 nvarchar(100),
    @am_city nvarchar(100),
    @am_state nvarchar(50),
    @am_pin nvarchar(10),
    @am_stdcode nvarchar(10),
    @am_phone nvarchar(12),
    @am_mobile1 nvarchar(11),
    @am_mobile2 nvarchar(11),
    @am_mail nvarchar(100),
    @users_uid int,
    @am_customer char(1),
    @am_default char(1),
    @am_district nvarchar(50),
    @am_tin nvarchar(50),
    @am_cst nvarchar(50),
    @am_climit decimal(12, 2),
    @am_lock char(1),
    @am_acccode nvarchar(20),
    @am_country nvarchar(50),
    @am_branch nvarchar(100),
    @am_account nvarchar(50),
    @am_bank nvarchar(100)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[accmaster]
	SET  [am_name] = @am_name, [am_shortname] = @am_shortname, [ag_id] = @ag_id, [am_pid] = @am_pid, [am_add1] = @am_add1, [am_add2] = @am_add2, [am_city] = @am_city, [am_state] = @am_state, [am_pin] = @am_pin, [am_stdcode] = @am_stdcode, [am_phone] = @am_phone, [am_mobile1] = @am_mobile1, [am_mobile2] = @am_mobile2, [am_mail] = @am_mail, [users_uid] = @users_uid, [am_udate] = GETDATE(),[am_customer] = @am_customer, [am_district] = @am_district, [am_tin] = @am_tin, [am_cst] = @am_cst, [am_lock] = @am_lock, [am_country] = @am_country, [am_branch] = @am_branch, [am_account] = @am_account, [am_bank] = @am_bank, [am_acccode] = @am_acccode
	WHERE  [am_id] = @am_id AND [am_default] = 'N'
	
	UPDATE [dbo].[accmaster]
	SET [am_shortname] = @am_shortname, [am_add1] = @am_add1, [am_add2] = @am_add2, [am_city] = @am_city, [am_state] = @am_state, [am_pin] = @am_pin, [am_stdcode] = @am_stdcode, [am_phone] = @am_phone, [am_mobile1] = @am_mobile1, [am_mobile2] = @am_mobile2, [am_mail] = @am_mail, [users_uid] = @users_uid, [am_udate] = GETDATE(),[am_customer] = @am_customer, [am_district] = @am_district, [am_tin] = @am_tin, [am_cst] = @am_cst, [am_climit] = @am_climit, [am_lock] = @am_lock, [am_country] = @am_account, [am_branch] = @am_branch, [am_account] = @am_account, [am_bank] = @am_bank, [am_acccode] = @am_acccode
	WHERE  [am_id] = @am_id AND [am_default] = 'Y'
	
	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_accmasterDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_accmasterDelete] 
END 
GO
CREATE PROC [dbo].[usp_accmasterDelete] 
    @am_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[accmaster]
	WHERE  [am_id] = @am_id AND [am_default] = 'N'

	COMMIT
GO
insert into accmaster(am_name,ag_id,users_uid,am_default) values('CASH IN HAND',5,1,'Y')
GO
insert into accmaster(am_name,ag_id,users_uid,am_default) values('CUSTOMER',13,1,'Y')
GO
/*acctype*/
IF OBJECT_ID('[dbo].[acctype]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].acctype
END 
GO
CREATE TABLE dbo.acctype
(
	type_id int identity primary key,
	type_name nvarchar(50) unique not null
)
GO
IF OBJECT_ID('[dbo].[usp_acctypeSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_acctypeSelect] 
END 
GO
CREATE PROC [dbo].[usp_acctypeSelect] 
    @type_id INT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [type_id], [type_name] 
	FROM   [dbo].[acctype] 
	WHERE  ([type_id] = @type_id OR @type_id IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_acctypeInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_acctypeInsert] 
END 
GO
CREATE PROC [dbo].[usp_acctypeInsert] 
    @type_name nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[acctype] ([type_name])
	SELECT @type_name
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_acctypeUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_acctypeUpdate] 
END 
GO
CREATE PROC [dbo].[usp_acctypeUpdate] 
    @type_id int,
    @type_name nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[acctype]
	SET    [type_name] = @type_name
	WHERE  [type_id] = @type_id

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_acctypeDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_acctypeDelete] 
END 
GO
CREATE PROC [dbo].[usp_acctypeDelete] 
    @type_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[acctype]
	WHERE  [type_id] = @type_id

	COMMIT
GO
/*amtype*/
IF OBJECT_ID('[dbo].[amtype]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].amtype
END 
GO
CREATE TABLE dbo.amtype
(
	type_id int foreign key references acctype(type_id),
	am_id int foreign key references accmaster(am_id),
	primary key (type_id,am_id)
)
GO
IF OBJECT_ID('[dbo].[usp_amtypeSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_amtypeSelect] 
END 
GO
CREATE PROC [dbo].[usp_amtypeSelect] 
    @am_id INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT at.[type_id], at.[am_id], a.[am_name], t.[type_name]
	FROM   [dbo].[amtype] at
	JOIN  [dbo].[accmaster] a on a.[am_id] = at.[am_id]
	JOIN  [dbo].[acctype] t on t.[type_id] = at.[type_id]
	WHERE  at.[am_id] = @am_id 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_amtypeInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_amtypeInsert] 
END 
GO
CREATE PROC [dbo].[usp_amtypeInsert] 
    @type_id int,
    @am_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[amtype] ([type_id], [am_id])
	SELECT @type_id, @am_id
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_amtypeUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_amtypeUpdate] 
END 
GO
CREATE PROC [dbo].[usp_amtypeUpdate] 
    @type_id int,
    @am_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[amtype]
	SET    [type_id] = @type_id, [am_id] = @am_id
	WHERE  [type_id] = @type_id
	       AND [am_id] = @am_id

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_amtypeDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_amtypeDelete] 
END 
GO
CREATE PROC [dbo].[usp_amtypeDelete] 
    @am_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[amtype]
	WHERE  [am_id] = @am_id

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
/*minvoice*/
IF OBJECT_ID('[dbo].[minvoice]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].minvoice
END 
GO
create table minvoice
(
	mi_id bigint primary key,
	am_id int foreign key references accmaster(am_id),
	com_id int foreign key references company(com_id),
	mi_billtype nvarchar(20),
	mi_billno nvarchar(20),
	mi_billdate datetime,
	mi_trantype nvarchar(20),
	mi_tranno bigint,
	mi_trandate datetime,
	mi_totamt decimal(12,2),
	mi_disper decimal(5,2),
	mi_disamt decimal(12,2),
	mi_taxper decimal(5,2),
	mi_taxamt decimal(12,2),
	mi_round decimal(12,2),
	mi_netamt decimal(12,2),
	mi_cash decimal(12,2),
	mi_credit decimal(12,2),
	mi_free decimal(12,2),
	mi_advamt decimal(12,2),
	mi_narration nvarchar(50),
	users_uid int foreign key references users(users_uid),
	mi_udate dateTime  default(getdate()),
	mi_desc nvarchar(50),
)
GO
IF OBJECT_ID('[dbo].[usp_minvoiceSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_minvoiceSelect] 
END 
GO
CREATE PROC [dbo].[usp_minvoiceSelect] 
    @mi_id BIGINT=NULL,
    @am_id INT=NULL,
	@md_billtype NVARCHAR(200)=NULL,
    @fdate DATETIME=NULL,
    @tdate DATETIME=NULL,
    @com_id INT=NULL,
    @paid CHAR(1)=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT m.[mi_id], m.[com_id], m.[mi_tranno], m.[mi_trandate], m.[mi_trantype], m.[am_id], m.[mi_billtype], m.[mi_billno], m.[mi_billdate], m.[mi_narration], m.[users_uid], m.[mi_udate], m.[mi_totamt], [mi_disper], [mi_disamt], [mi_taxper], [mi_taxamt], [mi_round], [mi_netamt], [mi_cash], [mi_credit], [mi_free], [mi_advamt],
	 mi_desc,
	p.[am_name], u.[users_name], c.[com_name],p.[am_add1], p.[am_add2], p.[am_city], p.[am_pin], p.[am_state], p.[am_phone], p.[am_mobile1], p.[am_tin], p.[am_cst],
	case when m.[mi_cash]<>0 then 'CASH BILL' when m.[mi_credit]<>0 then 'CREDIT BILL' else 'FREE ISSUE' end paytype
	FROM [dbo].[minvoice] m
	LEFT JOIN [dbo].[accmaster] p on p.[am_id] = m.[am_id]
	JOIN [dbo].[users] u on u.[users_uid] = m.[users_uid]
	JOIN [dbo].[company] c on c.[com_id] = m.[com_id]
	WHERE ([mi_id] = @mi_id OR @mi_id IS NULL)
		AND (m.[am_id] = @am_id OR @am_id IS NULL)
		AND (m.[com_id] = @com_id OR @com_id IS NULL)
		AND (m.[mi_billtype]  in (select item from fnSplit(@md_billtype,',')) OR @md_billtype IS NULL)
		AND (m.[mi_trandate] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
		AND (@paid IS NULL OR (@paid='Y' AND m.mi_credit=0) OR (@paid='N' AND m.mi_credit<>0))
	ORDER BY [mi_id]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_minvoiceInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_minvoiceInsert] 
END 
GO
CREATE PROC [dbo].[usp_minvoiceInsert] 
    @mi_id bigint output,
    @am_id int,
    @com_id int,
    @mi_billtype nvarchar(20),
    @mi_billno nvarchar(20),
    @mi_billdate datetime,
    @mi_trantype nvarchar(20),
    @mi_tranno bigint,
    @mi_trandate datetime,
    @mi_totamt decimal(12, 2),
    @mi_disper decimal(5, 2),
    @mi_disamt decimal(12, 2),
    @mi_taxper decimal(5, 2),
    @mi_taxamt decimal(12, 2),
    @mi_round decimal(12, 2),
    @mi_netamt decimal(12, 2),
    @mi_cash decimal(12, 2),
    @mi_credit decimal(12, 2),
    @mi_free decimal(12, 2),
    @mi_advamt decimal(12, 2),
    @mi_narration nvarchar(50),
    @users_uid int,
	@mi_desc nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	SET @mi_id = isnull((select max([mi_id]) from [minvoice]),0)+1;
	
	INSERT INTO [dbo].[minvoice] ([mi_id], [am_id], [com_id], [mi_billno], [mi_billdate],[mi_billtype], [mi_trantype], [mi_tranno], [mi_trandate], [mi_totamt], [mi_disper], [mi_disamt], [mi_taxper], [mi_taxamt], [mi_round], [mi_netamt], [mi_cash], [mi_credit], [mi_free], [users_uid], [mi_udate], [mi_narration],[mi_desc],[mi_advamt])
	SELECT @mi_id, @am_id, @com_id, @mi_billno, @mi_billdate, @mi_billtype, @mi_trantype, @mi_tranno, @mi_trandate, @mi_totamt, @mi_disper, @mi_disamt, @mi_taxper, @mi_taxamt, @mi_round, @mi_netamt, @mi_cash, @mi_credit, @mi_free, @users_uid, GETDATE(), @mi_narration, @mi_desc, @mi_advamt
	COMMIT
	RETURN @mi_id;
GO 
IF OBJECT_ID('[dbo].[usp_minvoiceUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_minvoiceUpdate] 
END 
GO
CREATE PROC [dbo].[usp_minvoiceUpdate] 
    @mi_id bigint,
    @am_id int,
    @com_id int,
    @mi_billtype nvarchar(20),
    @mi_billno nvarchar(20),
    @mi_billdate datetime,
    @mi_trantype nvarchar(20),
    @mi_tranno bigint,
    @mi_trandate datetime,
    @mi_totamt decimal(12, 2),
    @mi_disper decimal(5, 2),
    @mi_disamt decimal(12, 2),
    @mi_taxper decimal(5, 2),
    @mi_taxamt decimal(12, 2),
    @mi_round decimal(12, 2),
    @mi_netamt decimal(12, 2),
    @mi_cash decimal(12, 2),
    @mi_credit decimal(12, 2),
    @mi_free decimal(12, 2),
    @mi_advamt decimal(12, 2),
    @mi_narration nvarchar(50),
    @users_uid int,
	@mi_desc nvarchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	UPDATE [dbo].[minvoice]
	SET    [mi_id] = @mi_id, [am_id] = @am_id, [com_id] = @com_id, [mi_billtype] = @mi_billtype, [mi_billno] = @mi_billno, [mi_billdate] = @mi_billdate,[mi_trantype] = @mi_trantype, [mi_tranno] = @mi_tranno, [mi_trandate] = @mi_trandate, [mi_totamt] = @mi_totamt, [mi_disper] = @mi_disper, [mi_disamt] = @mi_disamt, [mi_taxper] = @mi_taxper, [mi_taxamt] = @mi_taxamt, [mi_round] = @mi_round, [mi_netamt] = @mi_netamt, [mi_cash] = @mi_cash, [mi_credit] = @mi_credit, [mi_free] = @mi_free, [users_uid] = @users_uid, [mi_udate] = GETDATE(), [mi_narration] = @mi_narration, [mi_desc] = @mi_desc
	WHERE  [mi_id] = @mi_id

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_minvoiceDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_minvoiceDelete] 
END 
GO
CREATE PROC [dbo].[usp_minvoiceDelete] 
    @mi_id bigint
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[minvoice]
	WHERE  [mi_id] = @mi_id

	COMMIT
GO
/*dinvoice*/
IF OBJECT_ID('[dbo].[dinvoice]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].dinvoice
END 
GO
create table dinvoice
(
	mi_id bigint foreign key references minvoice(mi_id),
	di_order int,
	di_agid bigint,
	di_agorder int,
	di_salid bigint,
	di_salorder int,
	mi_trandate date,
	item_id int foreign key references item(item_id),
	di_qty decimal(12,2),
	di_ri char(1),
	di_prate decimal(12,2),
	di_srate decimal(12,2),
	di_amt decimal(12,2),
	di_taxper decimal(5,2),
	di_taxamt decimal(12,2),
	di_close char(1),
	primary key(mi_id,di_order)
)
GO

/*invtax*/
IF OBJECT_ID('[dbo].[invtax]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].invtax
END 
GO
create table invtax
(
	mi_id bigint foreign key references minvoice(mi_id),
	mi_order int,
	tax_id int foreign key references tax(tax_id),
	tax_per decimal(5,2),
	tax_amt decimal(12,2),
	primary key (mi_id,mi_order)
)
GO
IF OBJECT_ID('[dbo].[usp_invtaxSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_invtaxSelect] 
END 
GO
CREATE PROC [dbo].[usp_invtaxSelect] 
    @mi_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [mi_id], [mi_order], i.[tax_id], i.[tax_per], i.[tax_amt], t.[tax_name]
	FROM   [dbo].[invtax] i 
	JOIN [dbo].[tax] t on t.[tax_id] = i.[tax_id]
	WHERE  (i.[mi_id] = @mi_id OR @mi_id IS NULL) 
	ORDER BY i.[mi_id], i.[mi_order]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_invtaxInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_invtaxInsert] 
END 
GO
CREATE PROC [dbo].[usp_invtaxInsert] 
    @mi_id bigint,
    @mi_order int,
    @tax_id int,
    @tax_per decimal(5, 2),
    @tax_amt decimal(12, 2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[invtax] ([mi_id], [mi_order], [tax_id], [tax_per], [tax_amt])
	SELECT @mi_id, @mi_order, @tax_id, @tax_per, @tax_amt
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_invtaxDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_invtaxDelete] 
END 
GO
CREATE PROC [dbo].[usp_invtaxDelete] 
    @mi_id bigint
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[invtax]
	WHERE  [mi_id] = @mi_id

	COMMIT
GO
/*stock*/
IF OBJECT_ID('[dbo].[stock]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].stock
END 
GO
create table stock
(
	item_id int foreign key references item(item_id),
	com_id int foreign key references company(com_id),
	di_qty decimal(12,2),
	primary key (item_id,com_id)
)
GO
IF OBJECT_ID('[dbo].[usp_stockSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockSelect] 
END
GO
CREATE PROC [dbo].[usp_stockSelect]
	@com_id INT=NULL,
    @item_id INT=NULL,
    @mi_id BIGINT=NULL
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRAN

	IF @mi_id is null
	BEGIN

		SELECT d.[item_id], isnull(s.[di_qty],0) [di_qty], d.[item_name],d.[item_id]  refno,
		d.[item_name] + ' - ' + cast(isnull(s.[di_qty],0) as varchar) mat_desc,
		isnull(r.[di_prate],0) di_prate
		FROM [dbo].[item] d
		LEFT JOIN [dbo].[stock] s on d.[item_id] = s.[item_id] and (s.[com_id] = @com_id OR @com_id IS NULL)
		LEFT JOIN (
			SELECT rm.com_id,rd.item_id,MAX(rd.di_srate) di_prate
			FROM  [dbo].[dinvoice] rd
			JOIN [dbo].[minvoice] rm ON rm.mi_id = rd.mi_id AND rd.di_close <> 'Y'
			GROUP BY rm.com_id,rd.item_id
			) as r ON r.com_id = s.com_id AND r.item_id = s.item_id
		WHERE  (d.[item_id] = @item_id OR @item_id IS NULL)
		ORDER BY d.[item_name]
	
	END
	ELSE
	BEGIN
	
		SELECT d.[item_id], isnull(s.[di_qty],0)+ISNULL(iss_qty,0) [di_qty], d.[item_name],d.[item_id]  refno,
		ISNULL(i.[iss_qty],0) [iss_qty],
		d.[item_name] + ' - ' +  cast(isnull(s.[di_qty],0)+ISNULL(iss_qty,0) as varchar) mat_desc,
		ISNULL(r.di_prate,0) AS di_prate
		FROM [dbo].[item] d
		LEFT JOIN [dbo].[stock] s ON d.[item_id] = s.[item_id] and (s.[com_id] = @com_id OR @com_id IS NULL)
		LEFT JOIN (
		SELECT item_id,SUM(d.di_qty) iss_qty
		FROM dinvoice d
		JOIN minvoice m on m.mi_id=d.mi_id and (d.mi_id=@mi_id or @mi_id is null)
		GROUP BY d.item_id) i ON i.item_id = s.item_id
		LEFT JOIN (
		SELECT rd.item_id, MAX(rd.di_prate) di_prate
		FROM dinvoice rd
		WHERE (rd.di_close <> 'Y' OR rd.mi_id = @mi_id)
		GROUP BY rd.item_id) r ON r.item_id = d.item_id
		WHERE  (d.[item_id] = @item_id OR @item_id IS NULL)
		ORDER BY d.[item_name]
	
	END
	
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_stockInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockInsert] 
END 
GO
CREATE PROC [dbo].[usp_stockInsert] 
    @item_id int,
    @com_id int,
    @di_qty decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[stock] ([item_id], [com_id], [di_qty])
	SELECT @item_id, @com_id, @di_qty
	
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_stockUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockUpdate] 
END 
GO
CREATE PROC [dbo].[usp_stockUpdate] 
    @item_id int,
    @com_id int,
    @di_qty decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[stock]
	SET    [di_qty] = @di_qty
	WHERE  [item_id] = @item_id AND [com_id] = @com_id

	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_stockDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockDelete] 
END 
GO
CREATE PROC [dbo].[usp_stockDelete] 
    @item_id int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[stock]
	WHERE  [item_id] = @item_id

	COMMIT
GO
/*stockdet*/
IF OBJECT_ID('[dbo].[stockdet]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].stockdet
END 
GO
create table stockdet
(
	mi_id bigint foreign key references minvoice(mi_id),
	di_order int,
	item_id int foreign key references item(item_id),
	di_qty decimal(12,2),
	primary key (mi_id,di_order)
)
GO
IF OBJECT_ID('[dbo].[usp_stockdetSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockdetSelect] 
END 
GO
CREATE PROC [dbo].[usp_stockdetSelect] 
    @mi_id BIGINT=NULL,
    @di_order INT=NULL,
    @item_id INT=NULL
AS
	SET NOCOUNT ON
	SET XACT_ABORT ON

	BEGIN TRAN

	IF @mi_id is not null AND @di_order is null
	BEGIN

		SELECT d.[mi_id], d.[di_order], d.[item_id], isnull(sd.[di_qty],0)+isnull(i.di_qty,0) [di_qty], dg.[item_name], i.[di_srate],
		dg.item_name +' / '+' (' + CONVERT(varchar,m.mi_trandate,105) + ') ' +
		CAST((isnull(sd.[di_qty],0)+isnull(i.di_qty,0)) as varchar) mat_desc,0 iss_qty,
		CAST(sd.mi_id as varchar)+','+CAST(sd.di_order as varchar) refno
		FROM [dbo].[item] dg
		LEFT JOIN [dbo].[dinvoice] i on i.[mi_id] = @mi_id and i.[item_id] = dg.[item_id]
		LEFT JOIN [dbo].[dinvoice] d on d.[mi_id] = i.[di_agid] and d.[di_order] = i.[di_agorder]
		LEFT JOIN [dbo].[minvoice] m on m.[mi_id] = d.[mi_id]
		LEFT JOIN [dbo].[stockdet] sd on d.[mi_id] = sd.[mi_id] AND d.[di_order] = sd.[di_order]
		WHERE dg.[item_id] = @item_id
		ORDER BY d.[mi_id], d.[di_order], dg.[item_name]

	END
	ELSE
	BEGIN

		SELECT sd.[mi_id], sd.[di_order], sd.[item_id], sd.[di_qty], dg.[item_name], d.[di_srate],
		dg.item_name +' / '+ ' (' + CONVERT(varchar,m.mi_trandate,105) + ') ' +
		CAST(sd.[di_qty] as varchar) mat_desc,0 iss_qty,
		CAST(sd.mi_id as varchar)+','+CAST(sd.di_order as varchar) refno
		FROM [dbo].[stockdet] sd
		JOIN [dbo].[dinvoice] d on d.[mi_id] = sd.[mi_id] AND d.[di_order] = sd.[di_order]
		JOIN [dbo].[minvoice] m on m.[mi_id] = sd.[mi_id]
		JOIN [dbo].[item] dg on dg.[item_id] = sd.[item_id]
		LEFT JOIN (
		SELECT d.mi_id, d.[di_order],SUM(d.di_qty) iss_qty
		FROM dinvoice d
		WHERE (d.mi_id=@mi_id or @mi_id is null)
		GROUP BY d.mi_id, d.[di_order]) i on i.mi_id = sd.mi_id and i.di_order = sd.di_order
		WHERE  (sd.[mi_id] = @mi_id OR @mi_id IS NULL)
			AND (sd.[di_order] = @di_order OR @di_order IS NULL)
			AND (sd.[item_id] = @item_id OR @item_id IS NULL)
		ORDER BY sd.[mi_id], sd.[di_order], dg.[item_name]

	END

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_stockdetInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockdetInsert] 
END 
GO
CREATE PROC [dbo].[usp_stockdetInsert] 
    @mi_id bigint,
    @di_order int,
    @item_id int,
    @di_qty decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[stockdet] ([mi_id], [di_order], [item_id], [di_qty])
	SELECT @mi_id, @di_order, @item_id, @di_qty
	
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_stockdetUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockdetUpdate] 
END 
GO
CREATE PROC [dbo].[usp_stockdetUpdate] 
    @mi_id bigint,
    @di_order int,
    @item_id int,
    @di_qty decimal(12,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[stockdet]
	SET    [mi_id] = @mi_id, [di_order] = @di_order, [item_id] = @item_id, [di_qty] = @di_qty
	WHERE  [mi_id] = @mi_id
	       AND [di_order] = @di_order

	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_stockdetDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockdetDelete] 
END 
GO
CREATE PROC [dbo].[usp_stockdetDelete] 
    @mi_id bigint,
    @di_order int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[stockdet]
	WHERE  [mi_id] = @mi_id
	       AND [di_order] = @di_order

	COMMIT
GO
/*usp_stockclose*/
IF OBJECT_ID('[dbo].[usp_stockclose]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockclose]
END 
GO
CREATE PROC [dbo].[usp_stockclose] 
    @refno bigint=null,
    @order int=null
AS 
	DECLARE @qty DECIMAL(12,2);
	
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	IF(ISNULL(@refno,0)<>0 AND ISNULL(@order,0)<>0)
	BEGIN

		SET @qty = ISNULL((select sum(di_qty) from dinvoice where di_agid = @refno and di_agorder = @order and di_ri = 'R'),0) - 
			ISNULL((select sum(di_qty) from dinvoice where di_agid = @refno and di_agorder = @order and di_ri = 'I'),0)
		IF (@qty = 0)
		BEGIN
			update dinvoice set di_close = 'Y' where di_agid = @refno and di_agorder = @order
		END
		ELSE
		BEGIN
			update dinvoice set di_close = 'N' where di_agid = @refno and di_agorder = @order
		END

	END

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_dinvoiceSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_dinvoiceSelect] 
END 
GO
CREATE PROC [dbo].[usp_dinvoiceSelect] 
    @mi_id BIGINT,
    @di_order INT,
	@mi_billtype NVARCHAR(200)=NULL,
    @type NVARCHAR(20)=NULL,
    @fdate DATE=NULL,
    @tdate DATE=NULL,
    @am_id INT=NULL,
    @item_id INT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
	       
	 IF(@type = 'SALE RET')
	BEGIN -- SALE RET
	
		SELECT d.[mi_id], [di_order], [di_agid], [di_agorder], d.[item_id], [di_qty], [di_ri], [di_prate], [di_srate], [di_amt], [di_taxper], [di_taxamt], [di_close] , d.[mi_trandate], 
		dg.item_name, m.[mi_tranno], p.[am_name], m.mi_totamt, m.mi_taxamt, m.mi_taxper, m.mi_disamt, m.mi_disper, m.mi_round, m.mi_netamt, co.[com_name], m.[mi_billtype], d.[di_qty]-isnull(r.retqty,0) retqty
		FROM [dbo].[dinvoice] d
		JOIN [dbo].[minvoice] m on m.[mi_id] = d.[mi_id]
		JOIN [dbo].[item] dg on dg.[item_id] = d.[item_id]
		JOIN [dbo].[company] co on co.[com_id] = m.[com_id]
		JOIN [dbo].[users] u on u.[users_uid] = m.[users_uid]
		JOIN [dbo].[accmaster] p on p.[am_id] = m.[am_id]
		LEFT JOIN (
		SELECT di_salid,di_salorder,SUM(di_qty) retqty
		FROM [dbo].[dinvoice]
		WHERE [di_salid]=@mi_id
		GROUP BY di_salid,di_salorder) r on r.di_salid=d.mi_id and r.di_salorder=d.di_order
		WHERE d.[mi_id] = @mi_id and datediff(day,m.[mi_trandate],GETDATE())<15 and m.[mi_cash] = m.[mi_netamt]
		AND d.[di_qty] > isnull(r.retqty,0)
		ORDER BY [mi_id], [di_order]
		
	END -- END SALE RET
	ELSE IF(@type = 'item WISE')
	BEGIN -- item WISE

		SELECT d.[di_ri], d.[item_id], dg.item_name, sum(d.[di_qty]) dd_stockpcs, sum(d.[di_amt]) dd_amount
		FROM [dbo].[dinvoice] d
		JOIN [dbo].[minvoice] m on m.[mi_id] = d.[mi_id]
		JOIN [dbo].[item] dg on dg.[item_id] = d.[item_id]
		WHERE (d.[mi_id] = @mi_id OR @mi_id IS NULL) 
			AND (d.[di_order] = @di_order OR @di_order IS NULL)
			AND (m.[mi_billtype]  in (select item from fnSplit(@mi_billtype,',')) OR @mi_billtype IS NULL)
			AND (m.[mi_trandate] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
		GROUP BY d.[di_ri], dg.[item_name], d.[item_id]
		ORDER BY  dg.[item_name]
	
	END -- END item WISE
	ELSE
	BEGIN -- DETAIL
	
		SELECT d.[mi_id], [di_order], [di_agid], [di_agorder], [di_salid], [di_salorder], d.[item_id],[di_qty], [di_ri],[di_prate], [di_srate], [di_amt], [di_taxper], [di_taxamt], [di_close], d.[mi_trandate],
		dg.item_name, m.[mi_tranno], p.[am_name], m.mi_totamt, m.mi_taxamt, m.mi_taxper, m.mi_disamt, m.mi_disper, m.mi_round, m.mi_netamt, co.[com_name], m.[mi_billtype], u.[users_name]
		FROM [dbo].[dinvoice] d
		JOIN [dbo].[minvoice] m on m.[mi_id] = d.[mi_id]
		JOIN [dbo].[item] dg on dg.[item_id] = d.[item_id]
		JOIN [dbo].[company] co on co.[com_id] = m.[com_id]
		JOIN [dbo].[users] u on u.[users_uid] = m.[users_uid]
		LEFT JOIN [dbo].[accmaster] p on p.[am_id] = m.[am_id]
		WHERE (d.[mi_id] = @mi_id OR @mi_id IS NULL) 
			AND (d.[di_order] = @di_order OR @di_order IS NULL)
			AND (m.[am_id] = @am_id OR @am_id IS NULL)
			AND (d.[item_id] = @item_id OR @item_id IS NULL)
			AND (m.[mi_billtype]  in (select item from fnSplit(@mi_billtype,',')) OR @mi_billtype IS NULL)
			AND (m.[mi_trandate] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
		ORDER BY [mi_id], [di_order]
	
	END -- END DETAIL

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_salesInvoice]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_salesInvoice] 
END 
GO
CREATE PROC [dbo].[usp_salesInvoice] 
    @mi_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
	
	SELECT d.[mi_id], max([di_srate]) [di_srate], max([di_amt]) [di_amt],
	max([di_prate]) [di_prate], sum([di_qty]) [di_qty], dg.item_name, d.item_id
	FROM [dbo].[dinvoice] d
	JOIN [dbo].[item] dg on dg.[item_id] = d.item_id
	WHERE d.[mi_id] = @mi_id
	GROUP BY d.[mi_id], d.[item_id], dg.[item_name]
	ORDER BY [mi_id]

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_dinvoiceInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_dinvoiceInsert] 
END 
GO
CREATE PROC [dbo].[usp_dinvoiceInsert] 
    @mi_id bigint,
    @di_order int,
    @di_agid bigint,
    @di_agorder int,
    @di_salid bigint,
    @di_salorder int,
    @mi_trandate date,
    @item_id int,
    @di_qty decimal(12,2),
    @di_ri char(1),
    @di_prate decimal(12, 2),
    @di_srate decimal(12, 2),
    @di_amt decimal(12, 2),
    @di_taxper decimal(5, 2),
    @di_taxamt decimal(12, 2),
    @di_close char(1)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	DECLARE @com_id int;

	BEGIN TRAN
		
	INSERT INTO [dbo].[dinvoice] ([mi_id], [di_order], [di_agid], [di_agorder], [di_salid], [di_salorder], [mi_trandate], [item_id], [di_qty], [di_ri] ,[di_prate], [di_srate], [di_amt], [di_taxper], [di_taxamt], [di_close])
	select @mi_id, @di_order, @di_agid, @di_agorder, @di_salid, @di_salorder, @mi_trandate, @item_id,@di_qty,@di_ri,@di_prate,@di_srate, @di_amt, @di_taxper, @di_taxamt, @di_close
	
	SELECT @com_id = com_id FROM minvoice WHERE mi_id = @mi_id;

	IF ((select count(item_id) from stock where item_id=@item_id and com_id=@com_id) = 0)
		EXEC usp_stockInsert @item_id,@com_id,0;

	IF(@di_ri = 'R')
	BEGIN

		IF(@mi_id = @di_agid and @di_order = @di_agorder)
			EXEC usp_stockdetInsert @mi_id,@di_order,@item_id,@di_qty;
		ELSE
			UPDATE stockdet SET di_qty = di_qty + @di_qty WHERE  mi_id=@di_agid and di_order=@di_agorder;

		UPDATE stock SET di_qty = di_qty + @di_qty WHERE item_id=@item_id and com_id=@com_id;
	
	END
	ELSE
	BEGIN
		UPDATE stockdet SET di_qty = di_qty - @di_qty WHERE mi_id=@di_agid and di_order=@di_agorder;
		DELETE FROM stockdet WHERE mi_id=@di_agid and di_order=@di_agorder and di_qty=0;
		UPDATE stock SET di_qty = di_qty - @di_qty WHERE item_id=@item_id and com_id=@com_id;
	END
	EXEC usp_stockclose @mi_id,@di_order;
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_dinvoiceDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_dinvoiceDelete] 
END 
GO
CREATE PROC [dbo].[usp_dinvoiceDelete] 
    @mi_id bigint
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	DECLARE @refno BIGINT;
	DECLARE @order INT;
	DECLARE @agref BIGINT;
	DECLARE @agord INT;
	DECLARE @qty INT;
	DECLARE @item_id INT;
	DECLARE @ri NVARCHAR(1);
	DECLARE @com_id INT;
	BEGIN TRAN
	DECLARE @cunames CURSOR;
	SET @cunames = CURSOR FOR SELECT d.[mi_id], d.[di_order], d.[di_agid], d.[di_agorder], d.[di_ri], d.[item_id], d.[di_qty], m.[com_id]
	FROM  [dbo].[dinvoice] d 
	JOIN [dbo].[minvoice] m ON m.[mi_id] = d.[mi_id] AND d.[mi_id] = @mi_id;
	OPEN @cunames;
	FETCH NEXT FROM @cunames INTO @refno,@order,@agref,@agord,@ri,@item_id,@qty,@com_id;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		IF(@ri = 'R')
		BEGIN

			IF(@refno = @agref and @order = @agord)
				DELETE FROM stockdet WHERE mi_id=@refno and di_order=@order;
			ELSE
			BEGIN
				UPDATE stockdet SET di_qty = di_qty - @qty WHERE mi_id=@agref and di_order=@agord;
				DELETE FROM stockdet WHERE mi_id=@agref and di_order=@agord and di_qty=0;
			END

			UPDATE stock SET di_qty = di_qty - @qty WHERE item_id=@item_id and com_id=@com_id;

		END
		ELSE
		BEGIN

			IF((select count(mi_id) from dinvoice WHERE mi_id=@agref and di_order=@agord) = 0)
				EXEC usp_stockdetInsert @agref,@agord,@item_id,0;
			UPDATE stockdet SET di_qty = di_qty + @qty WHERE mi_id=@agref and di_order=@agord;
			UPDATE stock SET di_qty = di_qty + @qty WHERE item_id=@item_id and com_id=@com_id;

		END
		
		EXEC usp_stockclose @refno,@order;

		FETCH NEXT FROM @cunames INTO @refno,@order,@agref,@agord,@ri,@item_id,@qty,@com_id;
	END
	
	CLOSE @cunames;
	DEALLOCATE @cunames;

	DELETE
	FROM   [dbo].[dinvoice]
	WHERE  [mi_id] = @mi_id

	COMMIT
GO
/*yearly*/
IF OBJECT_ID('[dbo].[yearly]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].yearly
END
GO
create table yearly
(
	year_fdate datetime,
	year_tdate datetime,
	year_field nvarchar(20),
	year_value int,
	primary key (year_fdate,year_field)
)
GO
IF OBJECT_ID('[dbo].[usp_getYearNo]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].usp_getYearNo 
END 
GO
create procedure usp_getYearNo
	@field nvarchar(50)=null,
	@curdate datetime=null,
	@no bigint OUTPUT
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
	insert into yearly(year_fdate,year_tdate,year_field) values(@SD,@ED,@field);
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
	@no bigint OUTPUT
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
	insert into yearly(year_fdate,year_tdate,year_field)
	values(@SD,@ED,@field)
	end
	select @no=isnull(year_value,0)+1 from yearly where @curdate between year_fdate and year_tdate and @field=year_field
	update yearly set year_value=isnull(year_value,0)+1 where @curdate between year_fdate and year_tdate and @field=year_field
	
end
GO
/*settings*/
IF OBJECT_ID('[dbo].[settings]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].[settings]
END 
GO
create table settings
(
	sett_name nvarchar(25) primary key,
	sett_str nvarchar(300) default(''),
	sett_num bigint default(0),
	sett_date datetime default('01-Jan-1900')
)
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
    @sett_num bigint
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

/*mail*/
IF OBJECT_ID('[dbo].[mail]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].mail
END 
GO
CREATE TABLE mail
(
	mail_server nvarchar(100),
	mail_from nvarchar(200),
	mail_uid nvarchar(100),
	mail_pwd nvarchar(100),
	mail_port int default(587),
	mail_to nvarchar(100),
	mail_ssl char(1) default('Y'),
	mail_dpath nvarchar(500),
	constraint PK_mail primary key(mail_server,mail_from)
)
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
    @mail_port int,
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
IF OBJECT_ID('[dbo].[usp_stockreport]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_stockreport]
END 
GO
CREATE PROC [dbo].[usp_stockreport]
    @type NVARCHAR(20)=NULL,
    @mat_type NVARCHAR(20)=NULL,
    @item_id INT=NULL,
    @date DATETIME
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
	
	IF(@type = 'item STOCK')
	BEGIN

		select d.item_id,d.item_name,
		isnull(t.op,0) op,isnull(t.rec,0) rec,isnull(t.iss,0) iss,
		isnull(t.op,0)+isnull(t.rec,0)-isnull(t.iss,0) cls
		from item d
		left join (
		select s.item_id,isnull(SUM(orec),0)-isnull(SUM(oiss),0) op,isnull(SUM(rec),0) rec,isnull(SUM(iss),0) iss
		from (
		select s.item_id,s.di_qty orec,0 oiss,0 rec,0 iss
		from dinvoice s
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='R' and s.mi_trandate<@date
		and (s.di_close<>'Y' or s.mi_id in (select i.di_agid from dinvoice i where i.mi_trandate>=@date))
		union all
		select s.item_id,0 orec,s.di_qty oiss,0 rec,0 iss
		from dinvoice s 
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='I' and s.mi_trandate<@date
		and (s.di_close<>'Y' or s.di_agid in (select i.di_agid from dinvoice i where i.mi_trandate>=@date))
		union all
		select s.item_id,0 orec,0 oiss,s.di_qty rec,0 iss
		from dinvoice s
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='R' and s.mi_trandate=@date
		union all
		select s.item_id,0 orec,0 oiss,0 rec,s.di_qty iss
		from dinvoice s 
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id
		where s.di_ri='I' and s.mi_trandate=@date
		) s group by s.item_id
		) t on t.item_id=d.item_id		

	END
	ELSE IF(@type = 'PURCAHSE STOCK')
	BEGIN
	
		select d.item_name,(CASE a.am_name WHEN '' THEN 'OPENING' ELSE a.am_name end) am_name,s.mi_trandate,s.di_srate,
		isnull(t.op,0) op,isnull(t.rec,0) rec,isnull(t.iss,0) iss,
		isnull(t.op,0)+isnull(t.rec,0)-isnull(t.iss,0) cls
		from (
		select s.di_agid,s.di_agorder,isnull(SUM(orec),0)-isnull(SUM(oiss),0) op,isnull(SUM(rec),0) rec,isnull(SUM(iss),0) iss
		from (
		select s.di_agid,s.di_agorder,s.di_qty orec,0 oiss,0 rec,0 iss
		from dinvoice s
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='R' and s.mi_trandate<@date
		and (s.di_close<>'Y' or s.mi_id in (select i.di_agid from dinvoice i where i.mi_trandate>=@date))
		union all
		select s.di_agid,s.di_agorder,0 orec,s.di_qty oiss,0 rec,0 iss
		from dinvoice s 
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='I' and s.mi_trandate<@date
		and (s.di_close<>'Y' or s.di_agid in (select i.di_agid from dinvoice i where i.mi_trandate>=@date))
		union all
		select s.di_agid,s.di_agorder,0 orec,0 oiss,s.di_qty rec,0 iss
		from dinvoice s
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='R' and s.mi_trandate=@date
		union all
		select s.di_agid,s.di_agorder,0 orec,0 oiss,0 rec,s.di_qty iss
		from dinvoice s 
		join minvoice m on m.mi_id=s.mi_id
		join item d on d.item_id=s.item_id 
		where s.di_ri='I' and s.mi_trandate=@date
		) s group by s.di_agid,s.di_agorder
		) t
		join dinvoice s on s.mi_id=t.di_agid and s.di_order=t.di_agorder
		join minvoice m on m.mi_id=s.mi_id
		join accmaster a on a.am_id=m.am_id
		join item d on d.item_id=s.item_id 
		
	END
	
	COMMIT TRAN
GO

--DEFAULT VALUES
INSERT INTO mail VALUES('smtp.gmail.com','sample@gmail.com','sample','',587,'sample@aol.com','Y','');
GO
INSERT INTO settings(sett_name,sett_str,sett_num) VALUES('backloc','',0);
GO


