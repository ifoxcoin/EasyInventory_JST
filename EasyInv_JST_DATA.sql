USE [EasyInv_JST]

DELETE FROM [dbo].[receipt]
GO
DELETE FROM [dbo].[stock]
GO
DELETE FROM [dbo].[payment]
GO
DELETE FROM [dbo].[openingbalance]
GO
DELETE FROM [dbo].[commissionreceipt]
GO
DELETE FROM [dbo].[salesdetails]
GO
DELETE FROM [dbo].[packingreceipt]
GO
DELETE FROM [dbo].[salesmaster]
GO
DELETE FROM [dbo].[purchasedetails]
GO
DELETE FROM [dbo].[item]
GO
DELETE FROM [dbo].[category]
GO
DELETE FROM [dbo].[purchasemaster]
GO
DELETE FROM [dbo].[ledgermaster]
GO
DELETE FROM [dbo].[route]
GO
GO



GO
SET IDENTITY_INSERT [dbo].[route] ON 
GO
INSERT [dbo].[route] ([rt_id], [rt_name], [rt_vehicleno], [rt_udate], [users_uid]) VALUES (0, N'---Select---', N'---Select---', CAST(N'2025-04-22T19:10:23.603' AS DateTime), NULL)
GO
INSERT [dbo].[route] ([rt_id], [rt_name], [rt_vehicleno], [rt_udate], [users_uid]) VALUES (1, N'Kochine', N'TN60AF5050', CAST(N'2025-04-22T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[route] ([rt_id], [rt_name], [rt_vehicleno], [rt_udate], [users_uid]) VALUES (2, N'Trichy', N'TN54AM3894', CAST(N'2025-04-23T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[route] ([rt_id], [rt_name], [rt_vehicleno], [rt_udate], [users_uid]) VALUES (3, N'Kambam', N'TN53DF2929', CAST(N'2025-04-25T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[route] OFF
GO
SET IDENTITY_INSERT [dbo].[ledgermaster] ON 
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (0, 0, N'', N'', N'---Select---', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, NULL, CAST(N'2017-03-25T15:30:34.277' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 0, N'0', 0, N'0')
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (307, 0, N'32', N'Customer', N'JJ TRADING COMPANY', N'III/837, JJ TRADING COMPANY', N'KALAYAPURAM THAMARAKUDY ROAD', N'KOLLAM', N'', N'', N'', N'', N'691505', N'', N'', N'', N'', N'', N'32AMXPG4350J1ZU', N'', N'1', N'SUPER SPECIAL RATE  (A)', 1, 1, CAST(N'2025-04-25T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 1, N'1', 2, N'Kerala')
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (308, 0, N'2', N'Customer', N'Pandi', N'', N'', N'Madurai', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'Kochine', N'', N'', N'1', N'SUPER SPECIAL RATE  (A)', 1, 1, CAST(N'2025-04-28T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 1, N'2', 2, N'0')
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (309, 0, N'3', N'Customer', N'Test', N'', N'', N'Madurai', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'Kochine', N'', N'', N'1', N'WHOLE SALE RATE  (C)', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 1, N'1', 0, N'0')
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (310, 0, N'4', N'Customer', N'Raja', N'', N'', N'Madurai', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'1', N'COST RATE', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 0, N'4', 0, N'0')
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (311, 0, N'5', N'Supplier', N'Pradeep', N'', N'', N'Chennai', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'1', N'COST RATE', 1, 1, CAST(N'2025-04-25T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 0, N'', 1, N'0')
GO
INSERT [dbo].[ledgermaster] ([led_id], [led_agid], [led_accountcode], [led_accounttype], [led_name], [led_address], [led_address1], [led_address2], [led_tname], [led_taddress], [led_taddress1], [led_taddress2], [led_pincode], [led_transport], [led_ownerphone], [led_ownername], [led_managername], [led_managerphone], [led_tin], [led_cst], [led_refno], [led_ratetype], [users_uid], [com_id], [led_udate], [led_disper], [led_isfreight], [led_deliveryorder], [rt_id], [led_state]) VALUES (318, 0, N'1', N'Customer', N'JOSE & CO', N'', N'', N'ATHIRAMPUZHA', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'1', N'SUPER SPECIAL RATE  (A)', 1, 1, CAST(N'2025-04-26T00:00:00.000' AS DateTime), CAST(0.00 AS Decimal(8, 2)), 0, N'5', 1, N'Kerala')
GO
SET IDENTITY_INSERT [dbo].[ledgermaster] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (0, N'---Select---', NULL, NULL, CAST(N'2017-03-25T15:30:34.240' AS DateTime), N'0', N'0')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (56, N'Gram', 2, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'மால்டா.கடலை', N'GR')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (57, N'White Gram', 2, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'வெள்ளை கடலை', N'WGR')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (58, N'Gram Dhall', 2, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'கடலை பருப்பு', N'GNK')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (59, N'Batri Dhall', 2, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'பட்ரி பருப்பு', N'BAT')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (60, N'Peas Dhall', 2, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'ஆஸ்தி பட் பருப்பு', N'AD')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (61, N'Gingelly Seed', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'எள்', N'GI SE')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (62, N'Menthi', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'வெந்தயம்', N'ME')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (63, N'Jeera', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'சீரகம்', N'JE')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (64, N'Corriander', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'மல்லி', N'COR')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (65, N'Souff', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'சோம்பு', N'SO')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (66, N'Javari', 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), N'ஜவ்வரிசி', N'JAV')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (67, N'Mustard', 1, 1, CAST(N'2025-04-24T00:00:00.000' AS DateTime), N'கடுகு', N'MUS')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (68, N'Soya', 1, 1, CAST(N'2025-04-26T00:00:00.000' AS DateTime), N'மீல் மேக்கர்', N'GK')
GO
INSERT [dbo].[category] ([cat_id], [cat_name], [com_id], [users_uid], [cat_udate], [cat_tamilname], [cat_code]) VALUES (69, N'Orid Dhall', 1, 1, CAST(N'2025-04-26T00:00:00.000' AS DateTime), N'உருட்டு உளுந்தம் பருப்பு', N'OD')
GO
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[item] ON 
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (0, N'', N'---Select---', NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(N'2017-03-25T15:30:34.257' AS DateTime), NULL, N'0', N'0', CAST(0.000 AS Decimal(18, 3)), N'0', 0, N'0')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (242, N'', N'Gram Tiger', 56, CAST(400.000 AS Decimal(18, 3)), CAST(500.000 AS Decimal(18, 3)), CAST(650.000 AS Decimal(18, 3)), CAST(625.000 AS Decimal(18, 3)), CAST(600.000 AS Decimal(18, 3)), CAST(550.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-25T00:00:00.000' AS DateTime), 1, N'Gram', N'மால்டா.கடலை', CAST(0.000 AS Decimal(18, 3)), N'Kg', 40, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (243, N'', N'Gingelly Seed', 61, CAST(400.000 AS Decimal(18, 3)), CAST(500.000 AS Decimal(18, 3)), CAST(675.000 AS Decimal(18, 3)), CAST(650.000 AS Decimal(18, 3)), CAST(600.000 AS Decimal(18, 3)), CAST(550.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-23T00:00:00.000' AS DateTime), 2, N'Gingelly', N'எள்', CAST(5.000 AS Decimal(18, 3)), N'Kg', 60, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (244, N'', N'MUSTARD', 67, CAST(3000.000 AS Decimal(18, 3)), CAST(3400.000 AS Decimal(18, 3)), CAST(3700.000 AS Decimal(18, 3)), CAST(3600.000 AS Decimal(18, 3)), CAST(3575.000 AS Decimal(18, 3)), CAST(3500.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-24T00:00:00.000' AS DateTime), 3, N'', N'', CAST(5.000 AS Decimal(18, 3)), N'Kg', 50, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (245, N'', N'JEERA', 63, CAST(7900.000 AS Decimal(18, 3)), CAST(8000.000 AS Decimal(18, 3)), CAST(8300.000 AS Decimal(18, 3)), CAST(8200.000 AS Decimal(18, 3)), CAST(8150.000 AS Decimal(18, 3)), CAST(8100.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-24T00:00:00.000' AS DateTime), 4, N'', N'', CAST(5.000 AS Decimal(18, 3)), N'Kg', 30, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (246, N'', N'SOUFF', 65, CAST(3400.000 AS Decimal(18, 3)), CAST(3500.000 AS Decimal(18, 3)), CAST(3700.000 AS Decimal(18, 3)), CAST(3650.000 AS Decimal(18, 3)), CAST(3600.000 AS Decimal(18, 3)), CAST(3570.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-24T00:00:00.000' AS DateTime), 5, N'', N'', CAST(5.000 AS Decimal(18, 3)), N'Kg', 30, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (247, N'', N'KESAR BIG SOYA', 68, CAST(1300.000 AS Decimal(18, 3)), CAST(1400.000 AS Decimal(18, 3)), CAST(1500.000 AS Decimal(18, 3)), CAST(1480.000 AS Decimal(18, 3)), CAST(1450.000 AS Decimal(18, 3)), CAST(1430.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-26T00:00:00.000' AS DateTime), 6, N'', N'', CAST(12.000 AS Decimal(18, 3)), N'Kg', 20, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (248, N'', N'SURYA ORID DHALL', 69, CAST(10400.000 AS Decimal(18, 3)), CAST(10500.000 AS Decimal(18, 3)), CAST(10725.000 AS Decimal(18, 3)), CAST(10700.000 AS Decimal(18, 3)), CAST(10650.000 AS Decimal(18, 3)), CAST(10600.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-26T00:00:00.000' AS DateTime), 7, N'', N'', CAST(0.000 AS Decimal(18, 3)), N'Kg', 50, N'Bags')
GO
INSERT [dbo].[item] ([item_id], [item_code], [item_name], [cat_id], [item_purchaserate], [item_costrate], [item_mrp], [item_wholesalerate], [item_specialrate], [item_supersepecialrate], [users_uid], [com_id], [item_udate], [item_serial], [item_fullname], [item_tamilname], [item_taxpercentage], [item_unit], [item_quantity], [item_unittype]) VALUES (249, N'', N'MAHARAJA ORID DHALL', 69, CAST(12800.000 AS Decimal(18, 3)), CAST(12500.000 AS Decimal(18, 3)), CAST(12750.000 AS Decimal(18, 3)), CAST(12700.000 AS Decimal(18, 3)), CAST(12650.000 AS Decimal(18, 3)), CAST(12550.000 AS Decimal(18, 3)), 1, 1, CAST(N'2025-04-26T00:00:00.000' AS DateTime), 8, N'', N'', CAST(0.000 AS Decimal(18, 3)), N'Kg', 50, N'Bags')
GO
SET IDENTITY_INSERT [dbo].[item] OFF
