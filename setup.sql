/****** Object:  Table [dbo].[Parts]    Script Date: 9/7/2012 4:21:16 PM ******/
DROP TABLE [dbo].[Parts]
GO
/****** Object:  Table [dbo].[hibernate_unique_key]    Script Date: 9/7/2012 4:21:16 PM ******/
DROP TABLE [dbo].[hibernate_unique_key]
GO
/****** Object:  Table [dbo].[hibernate_unique_key]    Script Date: 9/7/2012 4:21:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hibernate_unique_key](
	[next_hi] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parts]    Script Date: 9/7/2012 4:21:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parts](
	[PartId] [int] NOT NULL,
	[PartName] varchar(150) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[UpfrontPercent] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[PartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO


insert into hibernate_unique_key values ( 2 )
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Advanced Microcontroller',350,.1,32768)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Basic Microcontroller',125,.1,32769)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Articulated Tracks',2000,.25,32770)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Hexapod base assembly',2500,.25,32771)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('All terrain wheels',800,.1,32772)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Ruggedized 12vDC motor',1200,.25,32773)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Mechanical arm assembly',750,.1,32774)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Steel case sheathing',149,.1,32775)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Infrared sensor array',325,.1,32776)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Flexible whisker sensors',79,0,32777)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Rotating Joint Assembly',289,.1,32778)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Rotating Mobility Base Coupling',499,.1,32779)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Flux Capacitor',1879,.25,32780)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('External Battery Packs',399,.1,32781)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Articulated cutting wheel',275,.1,32782)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Retractable Claw',349,.1,32783)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Mountable Halogen Floodlights',100,.1,32784)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Universal Anchor Point',89,0,32785)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Binocular Camera Array',389,.1,32786)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Wire assortment',29,0,32787)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Assorted Gears and Bearings',39,0,32788)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Micro Servo Motor',69,0,32789)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('High Torque Stepper Motor',189,.1,32790)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Temperature Sensor',45,0,32791)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Sealed Gyro Module',618,.1,32792)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('Wireless Ethernet Adapter',55,0,32793)
INSERT INTO Parts (PartName, UnitPrice, UpfrontPercent, PartId) VALUES ('GPS Receiver',105,0,32794)
