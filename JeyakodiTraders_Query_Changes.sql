
--- 17-05-2025 CHanges

---Table Ledgermaster---

 Alter table ledgermaster add led_vehicleno nvarchar(100) default '' not null

								---[usp_ledgermasterInsert]---
ALTER PROC [dbo].[usp_ledgermasterInsert] 
    @led_agid BIGINT = NULL,
    @led_accountcode nvarchar(100),
    @led_accounttype nvarchar(100),
    @led_name nvarchar(100),
    @led_address nvarchar(100),
    @led_address1 nvarchar(100),
    @led_address2 nvarchar(100),
	@led_shippingaddress1 nvarchar(100),
    @led_shippingaddress2 nvarchar(100),
	@led_state nvarchar(100),
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
	@led_deliveryorder nvarchar(100),
	@led_vehicleno nvarchar(100),
    @led_tin nvarchar(100),
	@led_isfreight bit,
    @led_cst nvarchar(100),
    @led_refno nvarchar(100),
    @users_uid BIGINT = NULL,
    @com_id BIGINT = NULL,
	@rt_id BIGINT = NULL,
    @led_udate datetime = NULL,
    @led_ratetype nvarchar(100),
    @led_disper decimal(8,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[ledgermaster] ([led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_state], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone],[led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_refno], [users_uid], [com_id], [rt_id], [led_udate], [led_ratetype], [led_disper])
	SELECT @led_agid, @led_accountcode, @led_accounttype, @led_name, @led_address, @led_address1, @led_address2, @led_shippingaddress1, @led_shippingaddress2, @led_state, @led_tname, @led_taddress, @led_taddress1, @led_taddress2, @led_pincode, @led_transport, @led_ownerphone, @led_ownername, @led_managername, @led_managerphone, @led_deliveryorder, @led_vehicleno, @led_tin,@led_isfreight, @led_cst, @led_refno, @users_uid, @com_id, @rt_id, @led_udate, @led_ratetype, @led_disper
	
	-- Begin Return Select <- do not remove
	SELECT [led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_state], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone],[led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_refno], [users_uid], [com_id], [rt_id], [led_udate], [led_ratetype], [led_disper]
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT




								---[usp_ledgermasterUpdate]---
ALTER PROC [dbo].[usp_ledgermasterUpdate] 
    @led_id BIGINT,
    @led_agid BIGINT = NULL,
    @led_accountcode nvarchar(100),
    @led_accounttype nvarchar(100),
    @led_name nvarchar(100),
    @led_address nvarchar(100),
    @led_address1 nvarchar(100),
	@led_shippingaddress1 nvarchar(100),
    @led_shippingaddress2 nvarchar(100),
    @led_address2 nvarchar(100),
	@led_state nvarchar(100),
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
	@led_deliveryorder nvarchar(100),
	@led_vehicleno nvarchar(100),
    @led_tin nvarchar(100),
	@led_isfreight bit,
    @led_cst nvarchar(100),
    @led_refno nvarchar(100),
    @users_uid BIGINT = NULL,
    @com_id BIGINT = NULL,
	@rt_id BIGINT = NULL,
    @led_udate datetime = NULL,
    @led_ratetype nvarchar(100),
    @led_disper decimal(8,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[ledgermaster]
	SET    [led_agid] = @led_agid, [led_accountcode] = @led_accountcode, [led_accounttype] = @led_accounttype, [led_name] = @led_name, [led_address] = @led_address, [led_address1] = @led_address1, [led_address2] = @led_address2, [led_shippingaddress1] = @led_shippingaddress1, [led_shippingaddress2] = @led_shippingaddress2, [led_state] = @led_state, [led_tname] = @led_tname, [led_taddress] = @led_taddress, [led_taddress1] = @led_taddress1, [led_taddress2] = @led_taddress2, [led_pincode] = @led_pincode, [led_transport] = @led_transport, [led_ownerphone] = @led_ownerphone, [led_ownername] = @led_ownername, [led_managername] = @led_managername, [led_managerphone] = @led_managerphone, [led_deliveryorder] = @led_deliveryorder, [led_vehicleno] = @led_vehicleno, [led_tin] = @led_tin,[led_isfreight] = @led_isfreight, [led_cst] = @led_cst, [led_refno] = @led_refno, [users_uid] = @users_uid, [com_id] = @com_id, [rt_id] = @rt_id, [led_udate] = @led_udate, [led_ratetype] = @led_ratetype,[led_disper]=@led_disper
	WHERE  [led_id] = @led_id
	
	-- Begin Return Select <- do not remove
	SELECT [led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_state], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone],[led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_refno], [users_uid], [com_id], [rt_id], [led_udate], [led_ratetype],[led_disper]
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = @led_id	
	-- End Return Select <- do not remove

	COMMIT



									--- [usp_ledgermasterSelect]---

	ALTER PROC [dbo].[usp_ledgermasterSelect]   
    @led_id BIGINT=null,  
    @accounttype nvarchar(50)=null,  
    @searchbyname nvarchar(50)=null,  
    @searchbycode nvarchar(50)=null,
	@searchbyareacode nvarchar(50)=null, 
    @led_agid BIGINT=null  
      
AS   
 SET NOCOUNT ON   
 SET XACT_ABORT ON    
  
 BEGIN TRAN  
  
 SELECT [led_id], [led_agid], [led_accountcode], [led_ratetype],[led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_state], [led_pincode], [led_transport], [led_ownerphone], 
  
[led_ownername], [led_managername], [led_managerphone], [led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_disper],[led_refno], lm.users_uid,u.users_name ,com.com_name , lm.com_id, [led_udate], lm.rt_id, rt.rt_name, rt.rt_vehicleno  
 FROM   [dbo].[ledgermaster] lm  
 join company  com on lm .com_id  =com.com_id   
 join users  u on lm.users_uid =u.users_uid  
 join route rt on lm.rt_id = rt.rt_id
 WHERE  ([led_id] = @led_id OR @led_id IS NULL)   
 AND led_id<>0  
 AND  (led_accounttype =@accounttype or @accounttype IS NULL)  
 AND (led_name like '%'+@searchbyname+'%' or @searchbyname  IS NULL)
 AND (rt_name like '%'+@searchbyareacode+'%' or @searchbyareacode  IS NULL) 
 AND (led_address2  like @searchbycode +'%' or @searchbycode  IS NULL)  
 AND (led_agid  = @led_agid OR @led_agid IS NULL)  
 --order by led_id DESC  
 order by CONVERT(int,led_accountcode) Asc  
 COMMIT 
 
 
 
 --- Table SalesOrder
 
   alter table salesorder add so_status nvarchar(100) default 'Not Converted' not null
   
 --- Table SalesOrderDetails
 
   alter table salesorderdetails add od_soldqty decimal(18,3) default 0 not null
   alter table salesorderdetails add od_pendingqty decimal(18,3) default 0 not null
   
   
							---usp_salesorderInsert---

ALTER PROC [dbo].[usp_salesorderInsert]   
    @so_id BIGINT output,  
    @so_refno bigint,  
    @so_date datetime = NULL,  
    @led_id BIGINT = NULL,
    @so_totqty decimal(18, 3),
	@so_status nvarchar(100),
    @users_uid BIGINT = NULL,  
    @so_udate datetime = NULL,   
    @so_isclose bit = NULL  
AS   
 SET NOCOUNT ON   
 SET XACT_ABORT ON    
   
 BEGIN   
   
 INSERT INTO [dbo].[salesorder] ([so_refno], [so_date], [led_id], [so_totqty], [so_status], [users_uid], [so_udate], [so_isclose])  
 SELECT @so_refno, @so_date, @led_id, @so_totqty, @so_status, @users_uid, @so_udate, @so_isclose
   
 -- Begin Return Select <- do not remove  
 SELECT [so_id], [so_refno], [so_date], [led_id], [so_totqty], [so_status], [users_uid], [so_udate], [so_isclose]  
 FROM   [dbo].[salesorder]  
 WHERE  [so_id] = SCOPE_IDENTITY()  
 -- End Return Select <- do not remove  
        set @so_id     = SCOPE_IDENTITY()  
        return  @so_id    
          
                
 END  
 
 
 
 
								---usp_salesorderUpdate---
								
 ALTER PROC [dbo].[usp_salesorderUpdate]   
    @so_id BIGINT ,  
    @so_refno bigint,  
    @so_date datetime = NULL,  
    @led_id BIGINT = NULL,
    @so_totqty decimal(18, 3),
	@so_status nvarchar(100),
    @users_uid BIGINT = NULL,  
    @so_udate datetime = NULL,   
    @so_isclose bit = NULL  
AS   
 SET NOCOUNT ON   
 SET XACT_ABORT ON    
   
 BEGIN TRAN  
  
 UPDATE [dbo].[salesorder]  
 SET [so_refno] = @so_refno, [so_date] = @so_date, [led_id] = @led_id, [so_totqty] = @so_totqty, [so_status] = @so_status, [users_uid] = @users_uid, [so_udate] = @so_udate, [so_isclose] = @so_isclose
 WHERE  [so_id] = @so_id  
   
 -- Begin Return Select <- do not remove  
 SELECT [so_id], [so_refno], [so_date], [led_id], [so_totqty], [so_status], [users_uid], [so_udate], [so_isclose]  
 FROM   [dbo].[salesorder]  
 WHERE  [so_id] = @so_id   
 -- End Return Select <- do not remove  
  
 COMMIT   
 
 
 
 
									---usp_salesorderSelect---
 
 ALTER PROC [dbo].[usp_salesorderSelect]   
    @so_id BIGINT=null,  
    @led_id BIGINT =null,  
    @fdate DATETIME=NULL,  
    @tdate DATETIME=NULL,  
    @IsClose bit =NULL,  
    @so_refno BIGINT=null  
AS   
 SET NOCOUNT ON   
 SET XACT_ABORT ON    
  
 BEGIN TRAN  
  
 SELECT [so_id], [so_refno], [so_date],lm.led_accountcode, so.led_id, lm.led_name, lm.[led_address2], so.users_uid, u.users_name, [so_udate] ,so_isclose, so_totqty, [so_status]
 FROM   [dbo].[salesorder] so  
 join ledgermaster   lm on so.led_id =lm .led_id 
 join users  u on so.users_uid =u.users_uid  
 WHERE  ([so_id] = @so_id OR @so_id IS NULL)   
 AND (so.[led_id] = @led_id OR @led_id IS NULL or @led_id=0)  
 AND (so.so_refno = @so_refno OR @so_refno IS NULL or @so_refno=0)  
 AND (so.[so_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
 AND (so.[so_isclose] = @IsClose OR @IsClose IS NULL)  
 --AND (@IsClose IS NULL OR (@IsClose=1 AND sm.sm_received=0) OR (@IsClose=0 AND sm.sm_received<>0))   
 order by so_refno desc 
 COMMIT
 
 
 --- Table SalesOrderDetails 19-05-2025 Changes
 
								---usp_salesorderdetailsInsert---
--- Add od_rate field - 19-05-25
 
 ALTER PROC [dbo].[usp_salesorderdetailsInsert] 
    @so_id BIGINT,
    @item_id BIGINT,
    @od_qty decimal(18, 3),
	@od_soldqty decimal(18, 3),
	@od_pendingqty decimal(18, 3),
	@od_rate decimal(18, 3)
 
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[salesorderdetails] ([so_id], [item_id], [od_qty],  [od_soldqty], [od_pendingqty], [od_rate])
	SELECT @so_id, @item_id, @od_qty, @od_soldqty, @od_pendingqty, @od_rate
	
	-- Begin Return Select <- do not remove
	SELECT [od_id], [so_id], [item_id], [od_qty], [od_soldqty], [od_pendingqty], [od_rate]
	FROM   [dbo].[salesorderdetails]
	WHERE  [od_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
	
	
	
	
	
									---usp_salesorderdetailsSelect---
--- Add od_rate field - 19-05-25
	
ALTER PROC [dbo].[usp_salesorderdetailsSelect] 
    @so_id BIGINT=null,
    @fdate DATE=NULL,
    @tdate DATE=NULL,
    @led_id BIGINT=NULL,
    @item_id BIGINT=NULL,
    @cat_id BIGINT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [od_id], so.so_id, so.so_refno, so.so_date, so.so_totqty, lm.led_name, lm.led_id, lm.led_address,lm.led_address1,lm.led_address2,ct.cat_id,ct.cat_name, im.item_id,im.item_code ,im.item_name,im.item_unit,im.item_unittype,im.item_quantity ,im.item_purchaserate,im.item_costrate,item_mrp,im.item_specialrate,im.item_supersepecialrate,im.item_wholesalerate, [od_qty], [od_soldqty], [od_pendingqty], ct.com_id, im.item_taxpercentage, lm.led_ratetype, im.item_perunitrate, [od_rate]
	FROM   [dbo].[salesorderdetails] od
	join salesorder    so on od.so_id   =so.so_id  
	join ledgermaster   lm on so.led_id =lm .led_id 
	join item   im on od.item_id  =im.item_id 
	join category ct on ct.cat_id=im.cat_id
	join company com on com.com_id = ct.com_id
	WHERE  (od.[so_id] = @so_id OR @so_id IS NULL) 
	AND (lm.[led_id] = @led_id OR @led_id =0 OR @led_id IS NULL )
	AND (od.item_id = @item_id OR @item_id =0 OR @item_id IS NULL)
	AND (im.cat_id = @cat_id OR @cat_id =0 OR @cat_id  IS NULL)
	AND (so.[so_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	
	order by so_id desc 
	
	COMMIT
	
	
	
	
	
							---usp_salesorderdetailsUpdate---
--- Add od_rate field - 19-05-25

ALTER PROC [dbo].[usp_salesorderdetailsUpdate] 
    @od_id BIGINT,
    @so_id BIGINT,
    @item_id BIGINT,
    @od_qty decimal(18, 3),
	@od_soldqty decimal(18, 3),
	@od_pendingqty decimal(18, 3),
	@od_rate decimal(18, 3)

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[salesorderdetails]
	SET    [so_id] = @so_id, [item_id] = @item_id, [od_qty] = @od_qty, [od_soldqty] =  @od_soldqty, [od_pendingqty] = @od_pendingqty, [od_rate] = @od_rate
	WHERE  [od_id] = @od_id
	
	-- Begin Return Select <- do not remove
	SELECT [od_id], [so_id], [item_id], [od_qty], [od_soldqty], [od_pendingqty], [od_rate]
	FROM   [dbo].[salesorderdetails]
	WHERE  [od_id] = @od_id	
	-- End Return Select <- do not remove

	COMMIT
	
	
	
--- Table salesdetails

  alter table salesdetails add sd_orderqty decimal(18,3) default 0 not null
  
  
  
  
								---usp_salesdetailsInsert---
								
  ALTER PROC [dbo].[usp_salesdetailsInsert] 
    @sm_id BIGINT,
    @item_id BIGINT,
    @sd_qty decimal(18, 3),
	@sd_orderqty decimal(18, 3),
    @sd_rate decimal(18, 3),
    @sd_costrate decimal(18, 3),
    @sd_totamount decimal(18, 3),
	@sd_taxpercentage decimal(18, 3),
	@sd_taxamount decimal(18, 3),
	@sd_unit nvarchar(100),
	@sd_unitvalue int,
	@sd_itemunittype nvarchar(100),
	@sd_totfrieght decimal(18, 3),
	@sd_perunitrate decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[salesdetails] ([sm_id], [item_id], [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount], [sd_unit], [sd_unitvalue], [sd_itemunittype], [sd_totfrieght], [sd_perunitrate])
	SELECT @sm_id, @item_id, @sd_qty, @sd_orderqty, @sd_rate, @sd_costrate, @sd_totamount, @sd_taxpercentage, @sd_taxamount, @sd_unit, @sd_unitvalue, @sd_itemunittype, @sd_totfrieght, @sd_perunitrate
	
	-- Begin Return Select <- do not remove
	SELECT [sd_id], [sm_id], [item_id], [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount],  [sd_unit], [sd_unitvalue], [sd_itemunittype], [sd_totfrieght], [sd_perunitrate]
	FROM   [dbo].[salesdetails]
	WHERE  [sd_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
	
	
	
	
									---usp_salesdetailsSelect---
									
	ALTER PROC [dbo].[usp_salesdetailsSelect] 
    @sm_id BIGINT=null,
    @fdate DATE=NULL,
    @tdate DATE=NULL,
    @led_id BIGINT=NULL,
    @item_id BIGINT=NULL,
    @cat_id BIGINT=NULL,
	@com_id BIGINT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [sd_id], sm.sm_id,sm.sm_refno,sm.sm_date,sm.sm_disamount,sm.sm_netamount,sm.sm_packingcharge,sm.sm_totamount,sm.sm_profit,sm.sm_totqty,lm.led_name,lm.led_address,lm.led_address1,lm.led_address2,ct.cat_id,ct.cat_name, im.item_id,im.item_code ,im.item_name,im.item_unit,im.item_unittype,im.item_quantity ,im.item_purchaserate,im.item_costrate,item_mrp,im.item_specialrate,im.item_supersepecialrate,im.item_wholesalerate, [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount],  [sd_unit], [sd_unitvalue], [sd_itemunittype], im.item_perunitrate, [sd_totfrieght], [sd_perunitrate],com.com_id,com.com_name, im.item_fullname, ct.cat_hsncode
	FROM   [dbo].[salesdetails] sd
	join salesmaster    sm on sd.sm_id   =sm.sm_id  
	join ledgermaster   lm on sm.led_id =lm .led_id 
	join item   im on sd.item_id  =im.item_id 
	join company com on com.com_id = im.com_id
	join category ct on ct.cat_id=im.cat_id
	WHERE  (sd.[sm_id] = @sm_id OR @sm_id IS NULL) 
	AND (lm.[led_id] = @led_id OR @led_id =0 OR @led_id IS NULL )
	AND (sd.item_id = @item_id OR @item_id =0 OR @item_id IS NULL)
	AND (im.cat_id = @cat_id OR @cat_id =0 OR @cat_id  IS NULL)
	AND (im.com_id = @com_id OR @com_id =0 OR @com_id  IS NULL)
	AND (sm.[sm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	
	order by sm_id desc 
	
	COMMIT
	
	
	
	
								---usp_salesdetailsUpdate---
								
	ALTER PROC [dbo].[usp_salesdetailsUpdate] 
    @sd_id BIGINT,
    @sm_id BIGINT,
    @item_id BIGINT,
    @sd_qty decimal(18, 3),
	@sd_orderqty decimal(18, 3),
    @sd_rate decimal(18, 3),
    @sd_costrate decimal(18, 3),
    @sd_totamount decimal(18, 3),
	@sd_unit nvarchar(100),
	@sd_unitvalue int,
	@sd_itemunittype nvarchar(100),
	@sd_totfrieght decimal(18, 3),
	@sd_perunitrate decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[salesdetails]
	SET    [sm_id] = @sm_id, [item_id] = @item_id, [sd_qty] = @sd_qty, [sd_orderqty] = @sd_orderqty, [sd_rate] = @sd_rate, [sd_costrate] = @sd_costrate, [sd_totamount] = @sd_totamount,  [sd_unit] = @sd_unit, [sd_unitvalue] = @sd_unitvalue, [sd_itemunittype] = @sd_itemunittype, [sd_totfrieght] = @sd_totfrieght, [sd_perunitrate] = @sd_perunitrate
	WHERE  [sd_id] = @sd_id
	
	-- Begin Return Select <- do not remove
	SELECT [sd_id], [sm_id], [item_id], [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_unit], [sd_unitvalue], [sd_itemunittype], [sd_totfrieght], [sd_perunitrate]
	FROM   [dbo].[salesdetails]
	WHERE  [sd_id] = @sd_id	
	-- End Return Select <- do not remove

	COMMIT
	
	
	
	
	
	
---19-05-2025

---Table item

  Alter table item add item_purunitrate decimal (18,3) default 0 not null  
  
  
  
									--- usp_itemInsert
ALTER PROC [dbo].[usp_itemInsert] 
    @item_code nvarchar(100),
	@item_serial int,
    @item_name nvarchar(100),
	@item_fullname nvarchar(100),
	@item_tamilname nvarchar(100),
    @cat_id BIGINT,
	@item_isunitperrate bit,
	@item_perunitrate decimal(18, 3),
	@item_purunitrate decimal(18,3),
	@item_unit nvarchar(100),
	@item_quantity int,
	@item_unittype nvarchar(100),
    @item_purchaserate decimal(18, 3),
    @item_costrate decimal(18, 3),
    @item_mrp decimal(18, 3),
    @item_wholesalerate decimal(18, 3),
    @item_specialrate decimal(18, 3),
    @item_supersepecialrate decimal(18, 3),
	@item_taxpercentage decimal(18, 3),
    @users_uid BIGINT,
    @com_id BIGINT,
    @item_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[item] ([item_code],[item_serial], [item_name],[item_fullname], [item_tamilname], [cat_id], [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity], [item_unittype], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [item_taxpercentage], [users_uid], [com_id], [item_udate])
	SELECT @item_code,@item_serial, @item_name, @item_fullname, @item_tamilname, @cat_id, @item_isunitperrate, @item_perunitrate, @item_purunitrate, @item_unit, @item_quantity, @item_unittype, @item_purchaserate, @item_costrate, @item_mrp, @item_wholesalerate, @item_specialrate, @item_supersepecialrate, @item_taxpercentage, @users_uid, @com_id, @item_udate
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code],[item_serial], [item_name],[item_fullname], [item_tamilname], [cat_id], [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity], [item_unittype], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate],[item_taxpercentage], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
	
	
	
	
									---usp_itemSelect
									
ALTER PROC [dbo].[usp_itemSelect] 
    @item_id BIGINT=null,
    @search nvarchar(50)=null,
    @cat_id BIGINT =null,
	@item_code nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [item_id], [item_code],[item_serial], [item_name],[item_fullname], [item_tamilname], im.cat_id, [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity],[item_unittype], c.cat_name,[item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [item_taxpercentage], im.users_uid,u.users_name , com.com_id,com.com_name, [item_udate] 
	FROM   [dbo].[item] im
	join category c on im.cat_id =c.cat_id
	join company  com on im.com_id  =com.com_id 
	join users  u on im.users_uid =u.users_uid
	WHERE  ([item_id] = @item_id OR @item_id=0 OR @item_id IS NULL) 
	AND (c.cat_id = @cat_id OR @cat_id=0 OR @cat_id IS NULL) 	
	AND item_id<>0
	AND (item_name like '%'+@search+'%' or  @search='' or @search IS NULL)
	AND (item_code like '%'+@item_code+'%' or  @item_code='' or @item_code  IS NULL)
	order by im.item_serial,CONVERT(int, im.item_code) asc
	COMMIT
	
	
	
								---usp_itemUpdate
	
ALTER PROC [dbo].[usp_itemUpdate] 
    @item_id BIGINT,
    @item_code nvarchar(100),
	@item_serial int,
    @item_name nvarchar(100),
	@item_fullname nvarchar(100),
	@item_tamilname nvarchar(100),
    @cat_id BIGINT,
	@item_isunitperrate bit,
	@item_perunitrate decimal(18, 3),
	@item_purunitrate decimal(18,3),
	@item_unit nvarchar(100),
	@item_quantity int,
	@item_unittype nvarchar(100),
    @item_purchaserate decimal(18, 3),
    @item_costrate decimal(18, 3),
    @item_mrp decimal(18, 3),
    @item_wholesalerate decimal(18, 3),
    @item_specialrate decimal(18, 3),
    @item_supersepecialrate decimal(18, 3),
	@item_taxpercentage decimal(18, 3),
    @users_uid BIGINT,
    @com_id BIGINT,
    @item_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[item]
	SET    [item_code] = @item_code,item_serial=@item_serial, [item_name] = @item_name, [item_fullname] = @item_fullname, [item_tamilname] = @item_tamilname, [cat_id] = @cat_id, [item_isunitperrate] = @item_isunitperrate, [item_perunitrate] = @item_perunitrate, [item_purunitrate] = @item_purunitrate, [item_unit] = @item_unit, [item_quantity] = @item_quantity, [item_unittype] = @item_unittype, [item_purchaserate] = @item_purchaserate, [item_costrate] = @item_costrate, [item_mrp] = @item_mrp, [item_wholesalerate] = @item_wholesalerate, [item_specialrate] = @item_specialrate, [item_supersepecialrate] = @item_supersepecialrate, [item_taxpercentage] = @item_taxpercentage, [users_uid] = @users_uid, [com_id] = @com_id, [item_udate] = @item_udate
	WHERE  [item_id] = @item_id
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code],[item_serial], [item_name], [item_fullname], [item_tamilname], [cat_id], [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity], [item_unittype], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [item_taxpercentage], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = @item_id	
	-- End Return Select <- do not remove

	COMMIT
	
	
	
--- Store Procedure 	usp_GetItemList
	
ALTER PROC [dbo].[usp_GetItemList] 
    @item_id BIGINT=null,
    @cat_id BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
	
	
	select i.item_id,isnull(stk.AddQty,0) as AddQty,isnull(stk.LessQty,0)as LessQty,isnull(stk.stock,0) as stock,i.item_name, i.item_quantity, i.item_unit,i.item_taxpercentage,i.item_costrate,i.item_mrp,i.item_purchaserate,i.item_specialrate,i.item_supersepecialrate,
	i.item_wholesalerate from 
	(
	SELECT  i.[item_id], sum([stock_addqty]) as AddQty,
	 sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as stock
	FROM   [dbo].[stock] s
	left join item i on i.item_id=s.item_id
	group by i.item_id
	
	 )as stk
	right join item i on i.item_id=stk.item_id 
	where (i.cat_id=@cat_id or @cat_id is null)
	and (i.item_id = @item_id OR @item_id IS NULL)
	order by i.item_id ASC
	COMMIT



--- 21-05-2025 Changes

--- Table Salesdetails
  alter table salesdetails add sd_odid bigint null
  
  
										---usp_salesdetailsInsert
  
  ALTER PROC [dbo].[usp_salesdetailsInsert] 
    @sm_id BIGINT,
    @item_id BIGINT,
    @sd_qty decimal(18, 3),
	@sd_orderqty decimal(18, 3),
    @sd_rate decimal(18, 3),
    @sd_costrate decimal(18, 3),
    @sd_totamount decimal(18, 3),
	@sd_taxpercentage decimal(18, 3),
	@sd_taxamount decimal(18, 3),
	@sd_unit nvarchar(100),
	@sd_unitvalue int,
	@sd_itemunittype nvarchar(100),
	@sd_totfrieght decimal(18, 3),
	@sd_perunitrate decimal(18, 3),
	@sd_odid BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[salesdetails] ([sm_id], [item_id], [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount], [sd_unit], [sd_unitvalue], [sd_itemunittype], [sd_totfrieght], [sd_perunitrate], [sd_odid])
	SELECT @sm_id, @item_id, @sd_qty, @sd_orderqty, @sd_rate, @sd_costrate, @sd_totamount, @sd_taxpercentage, @sd_taxamount, @sd_unit, @sd_unitvalue, @sd_itemunittype, @sd_totfrieght, @sd_perunitrate, @sd_odid
	
	-- Begin Return Select <- do not remove
	SELECT [sd_id], [sm_id], [item_id], [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount],  [sd_unit], [sd_unitvalue], [sd_itemunittype], [sd_totfrieght], [sd_perunitrate], [sd_odid]
	FROM   [dbo].[salesdetails]
	WHERE  [sd_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
	
	
	
	
										---usp_salesdetailsSelect
	
ALTER PROC [dbo].[usp_salesdetailsSelect]
    @sm_id BIGINT=null,
    @fdate DATE=NULL,
    @tdate DATE=NULL,
    @led_id BIGINT=NULL,
    @item_id BIGINT=NULL,
    @cat_id BIGINT=NULL,
	@com_id BIGINT=NULL
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [sd_id], sm.sm_id,sm.sm_refno,sm.sm_date,sm.sm_disamount,sm.sm_netamount,sm.sm_packingcharge,sm.sm_totamount,sm.sm_profit,sm.sm_totqty,lm.led_name,lm.led_address,lm.led_address1,lm.led_address2,ct.cat_id,ct.cat_name, im.item_id,im.item_code ,im.item_name,im.item_unit,im.item_unittype,im.item_quantity ,im.item_purchaserate,im.item_costrate,item_mrp,im.item_specialrate,im.item_supersepecialrate,im.item_wholesalerate, [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount],  [sd_unit], [sd_unitvalue], [sd_itemunittype], im.item_perunitrate, [sd_totfrieght], [sd_perunitrate],com.com_id,com.com_name, im.item_fullname, ct.cat_hsncode, [sd_odid]
	FROM   [dbo].[salesdetails] sd
	join salesmaster    sm on sd.sm_id   =sm.sm_id  
	Left join salesorderdetails    od on sd.sd_odid   =od.od_id 
	join ledgermaster   lm on sm.led_id =lm .led_id 
	join item   im on sd.item_id  =im.item_id 
	join company com on com.com_id = im.com_id
	join category ct on ct.cat_id=im.cat_id
	WHERE  (sd.[sm_id] = @sm_id OR @sm_id IS NULL) 
	AND (lm.[led_id] = @led_id OR @led_id =0 OR @led_id IS NULL )
	AND (sd.item_id = @item_id OR @item_id =0 OR @item_id IS NULL)
	AND (im.cat_id = @cat_id OR @cat_id =0 OR @cat_id  IS NULL)
	AND (im.com_id = @com_id OR @com_id =0 OR @com_id  IS NULL)
	AND (sm.[sm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	
	order by sm_id desc 
	
	COMMIT
	
	
								---usp_salesdetailsUpdate
	
ALTER PROC [dbo].[usp_salesdetailsUpdate] 
    @sd_id BIGINT,
    @sm_id BIGINT,
    @item_id BIGINT,
    @sd_qty decimal(18, 3),
	@sd_orderqty decimal(18, 3),
    @sd_rate decimal(18, 3),
    @sd_costrate decimal(18, 3),
    @sd_totamount decimal(18, 3),
	@sd_taxpercentage decimal(18, 3),
	@sd_taxamount decimal(18, 3),
	@sd_unit nvarchar(100),
	@sd_unitvalue int,
	@sd_itemunittype nvarchar(100),
	@sd_totfrieght decimal(18, 3),
	@sd_perunitrate decimal(18, 3),
	@sd_odid BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[salesdetails]
	SET    [sm_id] = @sm_id, [item_id] = @item_id, [sd_qty] = @sd_qty, [sd_orderqty] = @sd_orderqty, [sd_rate] = @sd_rate, [sd_costrate] = @sd_costrate, [sd_totamount] = @sd_totamount, [sd_taxpercentage] = @sd_taxpercentage, [sd_taxamount] = @sd_taxamount,  [sd_unit] = @sd_unit, [sd_unitvalue] = @sd_unitvalue, [sd_itemunittype] = @sd_itemunittype, [sd_totfrieght] = @sd_totfrieght, [sd_perunitrate] = @sd_perunitrate, [sd_odid] = @sd_odid
	WHERE  [sd_id] = @sd_id
	
	-- Begin Return Select <- do not remove
	SELECT [sd_id], [sm_id], [item_id], [sd_qty], [sd_orderqty], [sd_rate], [sd_costrate], [sd_totamount], [sd_taxpercentage], [sd_taxamount],  [sd_unit], [sd_unitvalue], [sd_itemunittype], [sd_totfrieght], [sd_perunitrate], [sd_odid]
	FROM   [dbo].[salesdetails]
	WHERE  [sd_id] = @sd_id	
	-- End Return Select <- do not remove

	COMMIT
	
	
	
	
---  23-05-2025 Changes


--- Table item

  alter table item add item_hsncode nvarchar(100) default '' not null
  alter table item add item_cgst decimal(18,3) default 0 not null
  alter table item add item_sgst decimal(18,3) default 0 not null
  





								--- usp_itemInsert

ALTER PROC [dbo].[usp_itemInsert] 
    @item_code nvarchar(100),
	@item_serial int,
    @item_name nvarchar(100),
	@item_fullname nvarchar(100),
	@item_tamilname nvarchar(100),
    @cat_id BIGINT,
	@item_isunitperrate bit,
	@item_perunitrate decimal(18, 3),
	@item_purunitrate decimal(18,3),
	@item_unit nvarchar(100),
	@item_quantity int,
	@item_unittype nvarchar(100),
    @item_purchaserate decimal(18, 3),
    @item_costrate decimal(18, 3),
    @item_mrp decimal(18, 3),
    @item_wholesalerate decimal(18, 3),
    @item_specialrate decimal(18, 3),
    @item_supersepecialrate decimal(18, 3),
	@item_taxpercentage decimal(18, 3),
	@item_cgst decimal(18,3),
	@item_sgst decimal(18,3),
	@item_hsncode nvarchar(100),
    @users_uid BIGINT,
    @com_id BIGINT,
    @item_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[item] ([item_code],[item_serial], [item_name],[item_fullname], [item_tamilname], [cat_id], [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity], [item_unittype], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [item_taxpercentage], [item_cgst], [item_sgst], [item_hsncode], [users_uid], [com_id], [item_udate])
	SELECT @item_code,@item_serial, @item_name, @item_fullname, @item_tamilname, @cat_id, @item_isunitperrate, @item_perunitrate, @item_purunitrate, @item_unit, @item_quantity, @item_unittype, @item_purchaserate, @item_costrate, @item_mrp, @item_wholesalerate, @item_specialrate, @item_supersepecialrate, @item_taxpercentage, @item_cgst, @item_sgst, @item_hsncode, @users_uid, @com_id, @item_udate
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code],[item_serial], [item_name],[item_fullname], [item_tamilname], [cat_id], [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity], [item_unittype], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate],[item_taxpercentage], [item_cgst], [item_sgst], [item_hsncode], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT





								--- usp_itemSelect

ALTER PROC [dbo].[usp_itemSelect] 
    @item_id BIGINT=null,
    @search nvarchar(50)=null,
    @cat_id BIGINT =null,
	@item_code nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [item_id], [item_code],[item_serial], [item_name],[item_fullname], [item_tamilname], im.cat_id, [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity],[item_unittype], c.cat_name,[item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [item_taxpercentage], [item_cgst], [item_sgst], [item_hsncode], im.users_uid,u.users_name , com.com_id,com.com_name, [item_udate] 
	FROM   [dbo].[item] im
	join category c on im.cat_id =c.cat_id
	join company  com on im.com_id  =com.com_id 
	join users  u on im.users_uid =u.users_uid
	WHERE  ([item_id] = @item_id OR @item_id=0 OR @item_id IS NULL) 
	AND (c.cat_id = @cat_id OR @cat_id=0 OR @cat_id IS NULL) 	
	AND item_id<>0
	AND (item_name like '%'+@search+'%' or  @search='' or @search IS NULL)
	AND (item_code like '%'+@item_code+'%' or  @item_code='' or @item_code  IS NULL)
	order by im.item_serial,CONVERT(int, im.item_code) asc
	COMMIT
	
	
	
	
	
							--- usp_itemUpdate
	
ALTER PROC [dbo].[usp_itemUpdate] 
    @item_id BIGINT,
    @item_code nvarchar(100),
	@item_serial int,
    @item_name nvarchar(100),
	@item_fullname nvarchar(100),
	@item_tamilname nvarchar(100),
    @cat_id BIGINT,
	@item_isunitperrate bit,
	@item_perunitrate decimal(18, 3),
	@item_purunitrate decimal(18,3),
	@item_unit nvarchar(100),
	@item_quantity int,
	@item_unittype nvarchar(100),
    @item_purchaserate decimal(18, 3),
    @item_costrate decimal(18, 3),
    @item_mrp decimal(18, 3),
    @item_wholesalerate decimal(18, 3),
    @item_specialrate decimal(18, 3),
    @item_supersepecialrate decimal(18, 3),
	@item_taxpercentage decimal(18, 3),
	@item_cgst decimal(18,3),
	@item_sgst decimal(18,3),
	@item_hsncode nvarchar(100),
    @users_uid BIGINT,
    @com_id BIGINT,
    @item_udate datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[item]
	SET    [item_code] = @item_code,item_serial=@item_serial, [item_name] = @item_name, [item_fullname] = @item_fullname, [item_tamilname] = @item_tamilname, [cat_id] = @cat_id, [item_isunitperrate] = @item_isunitperrate, [item_perunitrate] = @item_perunitrate, [item_purunitrate] = @item_purunitrate, [item_unit] = @item_unit, [item_quantity] = @item_quantity, [item_unittype] = @item_unittype, [item_purchaserate] = @item_purchaserate, [item_costrate] = @item_costrate, [item_mrp] = @item_mrp, [item_wholesalerate] = @item_wholesalerate, [item_specialrate] = @item_specialrate, [item_supersepecialrate] = @item_supersepecialrate, [item_taxpercentage] = @item_taxpercentage, [item_cgst] = @item_cgst, [item_sgst] = @item_sgst, [item_hsncode] = @item_hsncode, [users_uid] = @users_uid, [com_id] = @com_id, [item_udate] = @item_udate
	WHERE  [item_id] = @item_id
	
	-- Begin Return Select <- do not remove
	SELECT [item_id], [item_code],[item_serial], [item_name], [item_fullname], [item_tamilname], [cat_id], [item_isunitperrate], [item_perunitrate], [item_purunitrate], [item_unit], [item_quantity], [item_unittype], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [item_taxpercentage], [item_cgst], [item_sgst], [item_hsncode], [users_uid], [com_id], [item_udate]
	FROM   [dbo].[item]
	WHERE  [item_id] = @item_id	
	-- End Return Select <- do not remove

	COMMIT




---27-05-2025 Changes

						---[usp_getCutomerByRoute]

ALTER PROCEDURE [dbo].[usp_getCutomerByRoute]
    @rt_id INT = NULL,
	@vh_id INT = NULL,
	@fdate DATE=NULL
AS
BEGIN
    SET NOCOUNT ON; 

	select lm.led_id, lm.led_name, lm.led_address2, lm.led_state, lm.led_deliveryorder, it.item_name, sd.sd_unit, sd.sd_unitvalue, sd.sd_qty, rt.rt_vehicleno, sm_date, it.item_fullname, it.item_tamilname, it.cat_id, cat.cat_name, lm.vh_id, vh.vh_number
	from salesmaster sm
	join salesdetails sd on sd.sm_id = sm.sm_id
	join item it on it.item_id = sd.item_id
	join category cat on cat.cat_id = it.cat_id
	join ledgermaster lm on lm.led_id = sm.led_id
	join vehicle vh on lm.vh_id = vh.vh_id
	join route rt on rt.rt_id = lm.rt_id
	where (lm.rt_id = @rt_id OR @rt_id IS NULL)
	AND (lm.vh_id = @vh_id OR @vh_id IS NULL)
	AND (sm.sm_date = @fdate OR @fdate IS NULL)
	ORDER BY lm.led_deliveryorder ASC;
END



---Table   vehicle   new table add

CREATE TABLE vehicle (
    vh_id BIGINT PRIMARY KEY not null,
    vh_number VARCHAR(100) default '' not null,
	vh_udate datetime null,
	users_uid bigint null
);


									---usp_vehicleInsert

CREATE PROCEDURE [dbo].[usp_vehicleInsert] 
    @vh_number NVARCHAR(100),
    @users_uid BIGINT,
    @vh_udate DATETIME
AS 
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRAN;

    INSERT INTO [dbo].[vehicle] ([vh_number], [users_uid], [vh_udate])
    VALUES (@vh_number, @users_uid, @vh_udate);

    -- Return the newly inserted record using SCOPE_IDENTITY()
    SELECT [vh_id], [vh_number], [users_uid], [vh_udate]
    FROM [dbo].[vehicle]
    WHERE [vh_id] = SCOPE_IDENTITY();

    COMMIT;
END;





									---usp_vehicleSelect

CREATE PROC [dbo].[usp_vehicleSelect] 
    @vh_id BIGINT=null,
    @search nvarchar(50)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [vh_id], [vh_number], [users_uid], [vh_udate]
	FROM   [dbo].[vehicle] vh
	WHERE  ([vh_id] = @vh_id OR @vh_id IS NULL) 
	AND vh_id<>0  
	AND (vh_number like '%'+@search+'%' or @search IS NULL)

	COMMIT





									---usp_vehicleUpdate

CREATE PROC [dbo].[usp_vehicleUpdate] 
    @vh_id BIGINT,
    @vh_number NVARCHAR(100),
    @users_uid BIGINT,
    @vh_udate DATETIME
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[vehicle]
	SET    [vh_number] = @vh_number, [users_uid] = @users_uid, [vh_udate] = @vh_udate
	WHERE  [vh_id] = @vh_id
	
	-- Begin Return Select <- do not remove
	SELECT [vh_number], [users_uid], [vh_udate]
	FROM   [dbo].[vehicle]
	WHERE  [vh_id] = @vh_id	
	-- End Return Select <- do not remove

	COMMIT




										---usp_vehicleDelete

CREATE PROC [dbo].[usp_vehicleDelete] 
    @vh_id BIGINT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[vehicle]
	WHERE  [vh_id] = @vh_id

	COMMIT
	
	
	
---Table  ledgermaster

ALTER TABLE ledgermaster add vh_id bigint default '' not null




									---usp_ledgermasterInsert

ALTER PROC [dbo].[usp_ledgermasterInsert] 
    @led_agid BIGINT = NULL,
    @led_accountcode nvarchar(100),
    @led_accounttype nvarchar(100),
    @led_name nvarchar(100),
    @led_address nvarchar(100),
    @led_address1 nvarchar(100),
    @led_address2 nvarchar(100),
	@led_shippingaddress1 nvarchar(100),
    @led_shippingaddress2 nvarchar(100),
	@led_state nvarchar(100),
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
	@led_deliveryorder nvarchar(100),
	@led_vehicleno nvarchar(100),
    @led_tin nvarchar(100),
	@led_isfreight bit,
    @led_cst nvarchar(100),
    @led_refno nvarchar(100),
    @users_uid BIGINT = NULL,
    @com_id BIGINT = NULL,
	@rt_id BIGINT = NULL,
	@vh_id BIGINT = NULL,
    @led_udate datetime = NULL,
    @led_ratetype nvarchar(100),
    @led_disper decimal(8,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[ledgermaster] ([led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_state], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone],[led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_refno], [users_uid], [com_id], [rt_id], [vh_id], [led_udate], [led_ratetype], [led_disper])
	SELECT @led_agid, @led_accountcode, @led_accounttype, @led_name, @led_address, @led_address1, @led_address2, @led_shippingaddress1, @led_shippingaddress2, @led_state, @led_tname, @led_taddress, @led_taddress1, @led_taddress2, @led_pincode, @led_transport, @led_ownerphone, @led_ownername, @led_managername, @led_managerphone, @led_deliveryorder, @led_vehicleno, @led_tin,@led_isfreight, @led_cst, @led_refno, @users_uid, @com_id, @rt_id, @vh_id, @led_udate, @led_ratetype, @led_disper
	
	-- Begin Return Select <- do not remove
	SELECT [led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_state], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone],[led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_refno], [users_uid], [com_id], [rt_id], [vh_id], [led_udate], [led_ratetype], [led_disper]
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
	
	
	
									---usp_ledgermasterSelect
	
ALTER PROC [dbo].[usp_ledgermasterSelect]   
    @led_id BIGINT=null,  
    @accounttype nvarchar(50)=null,  
    @searchbyname nvarchar(50)=null,  
    @searchbycode nvarchar(50)=null,
	@searchbyareacode nvarchar(50)=null, 
    @led_agid BIGINT=null  
      
AS   
 SET NOCOUNT ON   
 SET XACT_ABORT ON    
  
 BEGIN TRAN  
  
 SELECT [led_id], [led_agid], [led_accountcode], [led_ratetype],[led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_state], [led_pincode], [led_transport], [led_ownerphone], 
  
[led_ownername], [led_managername], [led_managerphone], [led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_disper],[led_refno], lm.users_uid,u.users_name ,com.com_name , lm.com_id, [led_udate], lm.rt_id, lm.vh_id, rt.rt_name, rt.rt_vehicleno, vh.vh_number  
 FROM   [dbo].[ledgermaster] lm  
 join company  com on lm .com_id  =com.com_id   
 join users  u on lm.users_uid =u.users_uid  
 join route rt on lm.rt_id = rt.rt_id
 join vehicle vh on lm.vh_id = vh.vh_id
 WHERE  ([led_id] = @led_id OR @led_id IS NULL)   
 AND led_id<>0  
 AND  (led_accounttype =@accounttype or @accounttype IS NULL)  
 AND (led_name like '%'+@searchbyname+'%' or @searchbyname  IS NULL)
 AND (rt_name like '%'+@searchbyareacode+'%' or @searchbyareacode  IS NULL) 
 AND (led_address2  like @searchbycode +'%' or @searchbycode  IS NULL)  
 AND (led_agid  = @led_agid OR @led_agid IS NULL)  
 --order by led_id DESC  
 order by CONVERT(int,led_accountcode) Asc  
 COMMIT 
 
 
 
									---usp_ledgermasterUpdate
 
ALTER PROC [dbo].[usp_ledgermasterUpdate] 
    @led_id BIGINT,
    @led_agid BIGINT = NULL,
    @led_accountcode nvarchar(100),
    @led_accounttype nvarchar(100),
    @led_name nvarchar(100),
    @led_address nvarchar(100),
    @led_address1 nvarchar(100),
	@led_shippingaddress1 nvarchar(100),
    @led_shippingaddress2 nvarchar(100),
    @led_address2 nvarchar(100),
	@led_state nvarchar(100),
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
	@led_deliveryorder nvarchar(100),
	@led_vehicleno nvarchar(100),
    @led_tin nvarchar(100),
	@led_isfreight bit,
    @led_cst nvarchar(100),
    @led_refno nvarchar(100),
    @users_uid BIGINT = NULL,
    @com_id BIGINT = NULL,
	@rt_id BIGINT = NULL,
	@vh_id BIGINT = NULL,
    @led_udate datetime = NULL,
    @led_ratetype nvarchar(100),
    @led_disper decimal(8,2)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[ledgermaster]
	SET    [led_agid] = @led_agid, [led_accountcode] = @led_accountcode, [led_accounttype] = @led_accounttype, [led_name] = @led_name, [led_address] = @led_address, [led_address1] = @led_address1, [led_address2] = @led_address2, [led_shippingaddress1] = @led_shippingaddress1, [led_shippingaddress2] = @led_shippingaddress2, [led_state] = @led_state, [led_tname] = @led_tname, [led_taddress] = @led_taddress, [led_taddress1] = @led_taddress1, [led_taddress2] = @led_taddress2, [led_pincode] = @led_pincode, [led_transport] = @led_transport, [led_ownerphone] = @led_ownerphone, [led_ownername] = @led_ownername, [led_managername] = @led_managername, [led_managerphone] = @led_managerphone, [led_deliveryorder] = @led_deliveryorder, [led_vehicleno] = @led_vehicleno, [led_tin] = @led_tin,[led_isfreight] = @led_isfreight, [led_cst] = @led_cst, [led_refno] = @led_refno, [users_uid] = @users_uid, [com_id] = @com_id, [rt_id] = @rt_id, [vh_id] = @vh_id, [led_udate] = @led_udate, [led_ratetype] = @led_ratetype,[led_disper]=@led_disper
	WHERE  [led_id] = @led_id
	
	-- Begin Return Select <- do not remove
	SELECT [led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_shippingaddress1], [led_shippingaddress2], [led_state], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone],[led_deliveryorder], [led_vehicleno], [led_tin],[led_isfreight], [led_cst], [led_refno], [users_uid], [com_id], [rt_id], [vh_id], [led_udate], [led_ratetype],[led_disper]
	FROM   [dbo].[ledgermaster]
	WHERE  [led_id] = @led_id	
	-- End Return Select <- do not remove

	COMMIT
	
	
	
	
	
SET IDENTITY_INSERT [EasyInv_JST].[dbo].[vehicle] ON;


INSERT INTO [EasyInv_JST].[dbo].[vehicle] (
    vh_id,
    vh_number,
    users_uid,
    vh_udate
)
VALUES (
    0,
    '--Select--',
    NULL, -- or a default user ID like 1 if NOT NULL constraint exists
    GETDATE()
);


SET IDENTITY_INSERT [EasyInv_JST].[dbo].[vehicle] OFF;



--- 30-05-2025 Changes
								---usp_stockSelect

ALTER PROC [dbo].[usp_stockSelect]
    @item_id BIGINT=null,
    @refid BIGINT=null,
	@fdate DATETIME=NULL,  
    @tdate DATETIME=NULL,
    @stockfrom nvarchar(10)=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT  im.[item_id], sum([stock_addqty]) as AddQty, sum([stock_lessqty]) as LessQty,(sum([stock_addqty])- sum([stock_lessqty])) as stock,  MAX(s.stock_date) AS stock_date
	FROM   [dbo].[stock] s
	JOIN item im on im.item_id=s.item_id
	WHERE  (im.item_id = @item_id OR @item_id IS NULL) 
	AND ([refid] = @refid OR @refid IS NULL) 
	AND (s.stock_date BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	AND (stockfrom = @stockfrom OR @stockfrom IS NULL) 
	group by im.item_id,im.item_serial,im.item_code
	order by im.item_serial,CONVERT(int, im.item_code) asc
	COMMIT





--- Table purchasemaster

  alter table purchasemaster add pm_billno nvarchar(100) default'' not null
  
  
  
  
  
									---usp_purchasemasterInsert
  
 ALTER PROC [dbo].[usp_purchasemasterInsert] 
    @pm_id BIGINT output,
    @pm_no BIGINT,
    @pm_date datetime = NULL,
    @led_id BIGINT = NULL,
    @pm_totqty decimal(18, 3),
    @pm_totamount decimal(18, 3),
	@pm_discountpercentage decimal(18, 3),
	@pm_discountamount decimal(18, 3),
	@pm_billno nvarchar(100),
    @com_id BIGINT = NULL,
    @users_uid BIGINT = NULL,
    @pm_udate datetime = NULL,
    @pm_desc nvarchar(50) = NULL,
    @pm_isclose bit = NULL,
	@pm_paid decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN 
	
	INSERT INTO [dbo].[purchasemaster] ([pm_no], [pm_date], [led_id], [pm_totqty], [pm_totamount], [pm_discountpercentage], [pm_discountamount], [pm_billno], [com_id], [users_uid], [pm_udate], [pm_desc], [pm_isclose], [pm_paid])
	SELECT @pm_no, @pm_date, @led_id, @pm_totqty, @pm_totamount, @pm_discountpercentage, @pm_discountamount, @pm_billno, @com_id, @users_uid, @pm_udate, @pm_desc, @pm_isclose, @pm_paid
	
	-- Begin Return Select <- do not remove
	SELECT [pm_id], [pm_no], [pm_date], [led_id], [pm_totqty], [pm_totamount], [pm_discountpercentage], [pm_discountamount], [pm_billno], [com_id], [users_uid], [pm_udate], [pm_desc], [pm_isclose], [pm_paid]
	FROM   [dbo].[purchasemaster]
	WHERE  [pm_id] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
	
       set @pm_id = SCOPE_IDENTITY()
        return  @pm_id      
	END
	
	
									---usp_purchasemasterSelect
	
ALTER PROC [dbo].[usp_purchasemasterSelect] 
    @pm_id BIGINT=null,
    @led_id BIGINT =null,
    @fdate DATETIME=NULL,
    @tdate DATETIME=NULL,
	@pm_isclose bit=Null,        
    @pm_no  BIGINT=null
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [pm_id], [pm_no], [pm_date], pm.led_id,lm.led_address2,lm.led_pincode,lm.led_tin,led_cst,lm.led_name,lm.led_address,lm.led_address1,lm.led_transport,lm.led_ownerphone, [pm_totqty], [pm_totamount], pm.users_uid,u.users_name , [pm_udate], [pm_desc], pm.com_id ,com.com_name ,pm_isclose, pm_paid, [pm_discountpercentage], [pm_discountamount], [pm_billno]
	FROM   [dbo].[purchasemaster] pm
	join ledgermaster   lm on pm.led_id =lm .led_id 
	join company  com on pm.com_id  =com.com_id 
	join users  u on pm.users_uid =u.users_uid
	WHERE  ([pm_id] = @pm_id OR @pm_id IS NULL) 
	AND (pm.[led_id] = @led_id OR @led_id IS NULL or @led_id=0)
	AND (pm.pm_no = @pm_no OR @pm_no IS NULL or @pm_no=0)
	AND (pm.[pm_isclose] = @pm_isclose OR @pm_isclose IS NULL)
	--AND (@pm_isclose IS NULL OR (@pm_isclose=1 AND pm.pm_isclose=0) OR (@pm_isclose=0 AND pm.pm_isclose<>0))
	AND (pm.[pm_date] BETWEEN @fdate AND @tdate OR @fdate IS NULL OR @tdate IS NULL)
	order by pm_no Asc
	COMMIT
	
	
	
	
										---usp_purchasemasterUpdate
	
	ALTER PROC [dbo].[usp_purchasemasterUpdate] 
    @pm_id BIGINT,
    @pm_no BIGINT,
    @pm_date datetime = NULL,
    @led_id BIGINT = NULL,
    @pm_totqty decimal(18, 3),
    @pm_totamount decimal(18, 3),
	@pm_discountpercentage decimal(18, 3),
	@pm_discountamount decimal(18, 3),
	@pm_billno nvarchar(100),
    @com_id BIGINT = NULL,
    @users_uid BIGINT = NULL,
    @pm_udate datetime = NULL,
    @pm_desc nvarchar(50) = NULL,
    @pm_isclose bit = NULL,
	@pm_paid decimal(18, 3)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[purchasemaster]
	SET    [pm_no] = @pm_no, [pm_date] = @pm_date, [led_id] = @led_id, [pm_totqty] = @pm_totqty, [pm_totamount] = @pm_totamount, [pm_discountpercentage] = @pm_discountpercentage, [pm_discountamount] = @pm_discountamount, [pm_billno] = @pm_billno, [com_id] = @com_id, [users_uid] = @users_uid, [pm_udate] = @pm_udate, [pm_desc] = @pm_desc, [pm_isclose] = @pm_isclose, [pm_paid] = @pm_paid
	WHERE  [pm_id] = @pm_id
	
	-- Begin Return Select <- do not remove
	SELECT [pm_id], [pm_no], [pm_date], [led_id], [pm_totqty], [pm_totamount], [pm_discountpercentage], [pm_discountamount], [pm_billno], [com_id], [users_uid], [pm_udate], [pm_desc], [pm_isclose], [pm_paid]
	FROM   [dbo].[purchasemaster]
	WHERE  [pm_id] = @pm_id	
	-- End Return Select <- do not remove

	COMMIT