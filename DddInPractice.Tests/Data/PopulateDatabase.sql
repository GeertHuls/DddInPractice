-- Run this script after the database is created
-- A fresh database is obtained using the 'CreateDatabase' from the TempDbTests class.

use SnackMachineDb

ALTER TABLE [dbo].[Ids]
ADD EntityName VARCHAR(50) NULL;
GO

INSERT INTO [dbo].[Snack]([SnackID], [Name])
SELECT 1, N'Chocolate' UNION ALL
SELECT 2, N'Soda' UNION ALL
SELECT 3, N'Gum';

INSERT INTO [dbo].[SnackMachine]([SnackMachineID], [OneCentCount], [TenCentCount], [QuarterCount], [OneDollarCount], [FiveDollarCount], [TwentyDollarCount])
SELECT 1, 1, 1, 1, 2, 2, 1

INSERT INTO [dbo].[Slot]([SlotID], [Position], [SnackMachineID], [Quantity], [Price], [SnackID])
SELECT 1, 1, 1, 1, 3.00000, 1 UNION ALL
SELECT 2, 2, 1, 5, 4.00000, 2 UNION ALL
SELECT 3, 3, 1, 10, 6.00000, 3;

INSERT INTO [dbo].[Atm]([AtmID], [MoneyCharged], [OneCentCount], [TenCentCount], [QuarterCount], [OneDollarCount], [FiveDollarCount], [TwentyDollarCount])
SELECT 1, 0.00000, 1, 1, 1, 1, 1, 1;

INSERT INTO [dbo].[HeadOffice]([HeadOfficeID], [Balance], [OneCentCount], [TenCentCount], [QuarterCount], [OneDollarCount], [FiveDollarCount], [TwentyDollarCount])
SELECT 1, 10.00000, 20, 20, 20, 20, 20, 20

DELETE FROM [dbo].[Ids] WHERE EntityName IS NULL;

INSERT INTO [dbo].[Ids]([NextHigh], [EntityName])
SELECT 1, N'Atm' UNION ALL
SELECT 1, N'Slot' UNION ALL
SELECT 1, N'Snack' UNION ALL
SELECT 1, N'SnackMachine' UNION ALL
SELECT 1, N'HeadOffice';
