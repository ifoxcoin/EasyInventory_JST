CREATE DATABASE EasyInv 
GO
USE EasyInv
GO
/*users*/
IF OBJECT_ID('[dbo].[users]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].users 
END 
GO
create table users
(
	users_uid bigint identity primary key not null,
	users_name nvarchar(25) unique default(''),
	users_pwd nvarchar(50) default(''),
	users_date datetime default (getdate()),
	users_pid bigint default 0,
	users_type char(1) default(''),
	users_lock char(1) default('N')
)
GO
insert into users(users_name,users_pwd,users_pid,users_type) values('ADMIN','p55HM/Xq3BUOmUIvTjCBlg==',0,'A')
GO
/*module*/
IF OBJECT_ID('[dbo].[module]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].module
END
GO
create table module
( 
	modulecode bigint NOT NULL primary key,
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
	formcode bigint primary key,
	modulecode bigint foreign key references module(modulecode),
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
	formcode bigint foreign key references form(formcode),
	ucode bigint,
	A Char(1) Default('N'),
	E Char(1) Default('N'),
	D Char(1)Default('N'),
	V Char(1) Default('N'),
	P Char(1) Default('N')
)
GO
/*company*/
IF OBJECT_ID('[dbo].[company]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].company
END 
GO
create table company
(
	com_id bigint identity primary key,
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
    @com_id bigint
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
	
	INSERT into [dbo].[company] ([com_name], [com_add1], [com_add2], [com_add3], [com_city], [com_state], [com_country], [com_phone], [com_mobile1], [com_mobile2], [com_fax], [com_pin], [com_email], [com_web], [com_default], [com_tin], [com_cst], [com_cstdate], [com_pan])
	SELECT @com_name, @com_add1, @com_add2, @com_add3, @com_city, @com_state, @com_country, @com_phone, @com_mobile1, @com_mobile2, @com_fax, @com_pin, @com_email, @com_web, @com_default, @com_tin, @com_cst, @com_cstdate, @com_pan
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_companyUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_companyUpdate] 
END 
GO
CREATE PROC [dbo].[usp_companyUpdate] 
    @com_id bigint,
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
    @com_id bigint
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

/*category*/
IF OBJECT_ID('[dbo].[category]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].category
END
GO
create table category
( 
	cat_id bigint identity primary key,
	cat_name nvarchar(100) not null default (''),
    com_id bigint foreign key references [company](com_id),
	users_uid bigint foreign key references users(users_uid),
	cat_udate datetime default(getdate())
)
GO
DBCC CHECKIDENT(category,RESEED,0);
GO
insert into category(cat_name) values('---Select---');
GO


/*item*/
IF OBJECT_ID('[dbo].[item]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].item 
END
GO
create table item 
( 
	item_id bigint identity primary key,
	item_code nvarchar(100) not null default (''),
	item_name nvarchar(100) not null default (''),	
	cat_id bigint  foreign key references category(cat_id),
	item_purchaserate decimal(18,3) not null default 0,
	item_costrate decimal(18,3) not null default 0,
	item_mrp decimal(18,3) not null default 0,
	item_wholesalerate decimal(18,3) not null default 0,
	item_specialrate decimal(18,3) not null default 0,
	item_supersepecialrate decimal(18,3) not null default 0,
	users_uid bigint foreign key references users(users_uid),
	com_id bigint foreign key references company(com_id),
	item_udate datetime default(getdate())
)
GO
DBCC CHECKIDENT(item,RESEED,0);
GO
insert into item(item_name) values('---Select---');
GO

 /*ledgermaster*/
IF OBJECT_ID('[dbo].[ledgermaster]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].ledgermaster
END
GO
create table ledgermaster
( 
led_id bigint identity primary key,
led_agid bigint default 0,
led_accountcode nvarchar(100) not null default(''),
led_accounttype nvarchar(100) not null default(''),
led_name nvarchar(100) not null default(''),
led_address nvarchar(100) not null default(''),
led_address1 nvarchar(100) not null default(''),
led_address2 nvarchar(100) not null default(''),
led_tname nvarchar(100) not null default(''),
led_taddress nvarchar(100) not null default(''),
led_taddress1 nvarchar(100) not null default(''),
led_taddress2 nvarchar(100) not null default(''),
led_pincode nvarchar(100) not null default(''),
led_transport nvarchar(100) not null default(''),
led_ownerphone nvarchar(100) not null default(''),
led_ownername nvarchar(100) not null default(''),
led_managername nvarchar(100) not null default(''),
led_managerphone nvarchar(100) not null default(''),
led_tin nvarchar(100) not null default(''),
led_cst nvarchar(100) not null default(''),
led_refno nvarchar(100) not null default(''),
led_ratetype nvarchar(100) not null default(''),

users_uid bigint foreign key references users(users_uid),
com_id bigint foreign key references company(com_id),
led_udate datetime default(getdate())
)
go
DBCC CHECKIDENT(ledgermaster,RESEED,0);
GO
insert into ledgermaster(led_name) values('---Select---');
GO
alter table ledgermaster add led_disper decimal(8,2)not null default 0
GO

/*purchasemaster*/
IF OBJECT_ID('[dbo].[purchasemaster]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].purchasemaster
END
GO
create table purchasemaster
( 
pm_id bigint identity primary key,
pm_no bigint not null default (''),
pm_date datetime,
led_id bigint foreign key references ledgermaster(led_id),
pm_totqty decimal(18,3) not null default (''),
pm_totamount decimal(18,3) not null default (''),
pm_isclose bit default 0,
com_id bigint foreign key references company(com_id),
users_uid bigint foreign key references users(users_uid),
pm_udate dateTime  default(getdate()),
pm_desc nvarchar(50)

)
GO

/*purchasedetails*/
IF OBJECT_ID('[dbo].[purchasedetails]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].purchasedetails
END
GO
create table purchasedetails
( 
pd_id bigint identity primary key ,
pm_id bigint foreign key references purchasemaster(pm_id),
item_id bigint foreign key references item(item_id),
cat_id bigint  foreign key references category(cat_id),
pd_particulars nvarchar(100) not null default(''),
pd_qty decimal(18,3) not null default 0,
pd_prate decimal(18,3) not null default 0,
pd_amount decimal(18,3) not null default 0

)
GO

/*salesmaster*/
IF OBJECT_ID('[dbo].[salesmaster]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].salesmaster
END
GO
create table salesmaster
( 
sm_id bigint identity primary key,
sm_bookno nvarchar(100) not null default (''),
sm_refno bigint not null default (''),
sm_date datetime,
led_id bigint foreign key references ledgermaster(led_id),
sm_totqty decimal(18,3) not null default (''),
sm_totamount decimal(18,3) not null default (''),
sm_itemcount bigint,
sm_profit decimal(18,3) not null default (''),
sm_disamount decimal(18,3) not null default (''),
sm_packingcharge decimal(18,3) not null default (''),
sm_paidpacking decimal(18,3) not null default (''),
sm_netamount decimal(18,3) not null default (''),
sm_received decimal(18,3) not null default (''),
sm_paidcommission decimal(18,3) not null default (''),
sm_iscommissionclose bit default 0,
sm_ispackingclose bit default 0,
sm_isclose bit default 0,
users_uid bigint foreign key references users(users_uid),
sm_udate dateTime  default(getdate()),
sm_desc nvarchar(50)
)
GO
/*salesdetails*/
IF OBJECT_ID('[dbo].[salesdetails]') IS NOT NULL
BEGIN
    DROP TABLE [dbo].salesdetails
END
GO
create table salesdetails
( 
sd_id bigint identity primary key ,
sm_id bigint foreign key references salesmaster(sm_id),
item_id bigint foreign key references item(item_id),
sd_qty decimal(18,3) not null default 0,
sd_rate decimal(18,3) not null default 0,
sd_costrate decimal(18,3) not null default 0,
sd_totamount decimal(18,3) not null default 0

)
GO

/*stock*/
IF OBJECT_ID('[dbo].[stock]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].stock
END 
GO
create table stock
(
	id bigint primary key identity ,
	refid bigint not null default 0,
	stockfrom nvarchar(10) not null default'',
	item_id bigint foreign key references item(item_id),
	com_id bigint foreign key references company(com_id),
	stock_addqty decimal(12,2) not null default 0,
	stock_lessqty decimal(12,2) not null default 0,
	stock_date datetime default getdate()
)
GO


/*receipt*/
IF OBJECT_ID('[dbo].[receipt]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].receipt
END 
GO
create table receipt
(
	id bigint primary key identity ,
	rec_no bigint not null default 0,
	rec_date datetime default getdate(),
	led_id bigint foreign key references ledgermaster(led_id),	
	sm_id bigint foreign key references salesmaster(sm_id),
	com_id bigint foreign key references company(com_id),
	rec_billamt decimal(12,2) not null default 0,
	rec_receivedamt decimal(12,2) not null default 0,
	rec_newbalance decimal(12,2) not null default 0,
	rec_isclose bit default 0
)
GO


/*commissionreceipt*/
IF OBJECT_ID('[dbo].[commissionreceipt]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].commissionreceipt
END 
GO
create table commissionreceipt
(
	id bigint primary key identity ,
	cr_no bigint not null default 0,
	cr_date datetime default getdate(),
	led_agid bigint foreign key references ledgermaster(led_id),	
	sm_id bigint foreign key references salesmaster(sm_id),
	com_id bigint foreign key references company(com_id),
	cr_billamt decimal(12,2) not null default 0,
	cr_receivedamt decimal(12,2) not null default 0,
	cr_newbalance decimal(12,2) not null default 0,
	cr_isclose bit default 0
)
GO


/*packingreceipt*/
IF OBJECT_ID('[dbo].[packingreceipt]') IS NOT NULL
BEGIN 
    DROP TABLE [dbo].packingreceipt
END 
GO
create table packingreceipt
(
	id bigint primary key identity ,
	pr_no bigint not null default 0,
	pr_date datetime default getdate(),
	led_agid bigint foreign key references ledgermaster(led_id),	
	sm_id bigint foreign key references salesmaster(sm_id),
	com_id bigint foreign key references company(com_id),
	pr_billamt decimal(12,2) not null default 0,
	pr_receivedamt decimal(12,2) not null default 0,
	pr_newbalance decimal(12,2) not null default 0,
	pr_isclose bit default 0
)
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
	year_value bigint,
	primary key (year_fdate,year_field)
)
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
	mail_port bigint default(587),
	mail_to nvarchar(100),
	mail_ssl char(1) default('Y'),
	mail_dpath nvarchar(500),
	constraint PK_mail primary key(mail_server,mail_from)
)
GO
INSERT into mail VALUES('smtp.gmail.com','sample@gmail.com','sample','',587,'sample@aol.com','Y','');
GO
INSERT into settings(sett_name,sett_str,sett_num) VALUES('backloc','',0);
GO


alter table salesmaster add  sm_paidpacking decimal(18,3) not null default (0)
alter table salesmaster add  sm_paidcommission decimal(18,3) not null default (0)
alter table salesmaster add  sm_iscommissionclose bit default 0
alter table salesmaster add  sm_ispackingclose bit default 0
