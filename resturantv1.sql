-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 09, 2022 at 10:47 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `resturantv1`
--

-- --------------------------------------------------------

--
-- Table structure for table `address`
--

CREATE TABLE `address` (
  `AddressId` int(11) NOT NULL,
  `city` varchar(50) DEFAULT NULL,
  `homeLocation` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `address`
--

INSERT INTO `address` (`AddressId`, `city`, `homeLocation`) VALUES
(1, 'Gaza', 'Palastin');

-- --------------------------------------------------------

--
-- Table structure for table `fullreport`
--

CREATE TABLE `fullreport` (
  `ReportId` int(11) NOT NULL,
  `supplyingDate` datetime NOT NULL,
  `goodsName` varchar(100) DEFAULT NULL,
  `supplierName` varchar(100) DEFAULT NULL,
  `storage` int(11) NOT NULL,
  `EachSupplierTotal` double NOT NULL,
  `TotalOfPurchase` double NOT NULL,
  `ManagerId` int(11) NOT NULL,
  `InvoiceId` int(11) NOT NULL,
  `SupplyingInvoiceInvoiceId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `manager`
--

CREATE TABLE `manager` (
  `ManagerId` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phoneNumber` int(11) NOT NULL,
  `AddressId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `manager`
--

INSERT INTO `manager` (`ManagerId`, `username`, `password`, `email`, `phoneNumber`, `AddressId`) VALUES
(2, 'Naajed', NULL, 'najed@mail.com', 564897532, 1);

-- --------------------------------------------------------

--
-- Table structure for table `stockitems`
--

CREATE TABLE `stockitems` (
  `StockId` int(11) NOT NULL,
  `stockNumber` int(11) NOT NULL,
  `goodsName` varchar(100) DEFAULT NULL,
  `storage` int(11) NOT NULL,
  `SupplyingId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `SupplierId` int(11) NOT NULL,
  `supplierName` varchar(50) DEFAULT NULL,
  `supplierPhone` varchar(10) DEFAULT NULL,
  `supplierNumber` int(11) NOT NULL,
  `supplierLocation` varchar(100) DEFAULT NULL,
  `ManagerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`SupplierId`, `supplierName`, `supplierPhone`, `supplierNumber`, `supplierLocation`, `ManagerId`) VALUES
(1, 'Najd', '0594627477', 1, 'saffa', 2),
(3, 'ahmed', '0597634566', 2, 'asd', 2),
(4, 'asdasd', '0596446464', 3, 'sdasd', 2),
(5, 'test', '0785798798', 4, 'asdasd', 2);

-- --------------------------------------------------------

--
-- Table structure for table `supplying`
--

CREATE TABLE `supplying` (
  `SupplyingId` int(11) NOT NULL,
  `supplyingNumber` int(11) NOT NULL,
  `supplyingDate` datetime NOT NULL,
  `goodsName` varchar(100) DEFAULT NULL,
  `amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `supplyinginvoice`
--

CREATE TABLE `supplyinginvoice` (
  `InvoiceId` int(11) NOT NULL,
  `invoiceDate` datetime NOT NULL,
  `goodsName` varchar(100) DEFAULT NULL,
  `supplierName` varchar(100) DEFAULT NULL,
  `discount` double NOT NULL,
  `goodsAmount` int(11) NOT NULL,
  `price` double NOT NULL,
  `APDTotalCost` double NOT NULL,
  `TotalOfPurchase` double NOT NULL,
  `InvoiceStatus` varchar(50) DEFAULT NULL,
  `SupplyingId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `supplyingprocess`
--

CREATE TABLE `supplyingprocess` (
  `Id` int(11) NOT NULL,
  `SupplierId` int(11) NOT NULL,
  `SupplyingId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220808194358_InitialModel', '5.0.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`AddressId`);

--
-- Indexes for table `fullreport`
--
ALTER TABLE `fullreport`
  ADD PRIMARY KEY (`ReportId`),
  ADD KEY `IX_FullReport_ManagerId` (`ManagerId`),
  ADD KEY `IX_FullReport_SupplyingInvoiceInvoiceId` (`SupplyingInvoiceInvoiceId`);

--
-- Indexes for table `manager`
--
ALTER TABLE `manager`
  ADD PRIMARY KEY (`ManagerId`),
  ADD KEY `IX_Manager_AddressId` (`AddressId`);

--
-- Indexes for table `stockitems`
--
ALTER TABLE `stockitems`
  ADD PRIMARY KEY (`StockId`),
  ADD KEY `IX_StockItems_SupplyingId` (`SupplyingId`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`SupplierId`),
  ADD KEY `IX_Supplier_ManagerId` (`ManagerId`);

--
-- Indexes for table `supplying`
--
ALTER TABLE `supplying`
  ADD PRIMARY KEY (`SupplyingId`);

--
-- Indexes for table `supplyinginvoice`
--
ALTER TABLE `supplyinginvoice`
  ADD PRIMARY KEY (`InvoiceId`),
  ADD KEY `IX_SupplyingInvoice_SupplyingId` (`SupplyingId`);

--
-- Indexes for table `supplyingprocess`
--
ALTER TABLE `supplyingprocess`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_SupplyingProcess_SupplierId` (`SupplierId`),
  ADD KEY `IX_SupplyingProcess_SupplyingId` (`SupplyingId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `address`
--
ALTER TABLE `address`
  MODIFY `AddressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `fullreport`
--
ALTER TABLE `fullreport`
  MODIFY `ReportId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `manager`
--
ALTER TABLE `manager`
  MODIFY `ManagerId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `stockitems`
--
ALTER TABLE `stockitems`
  MODIFY `StockId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `SupplierId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `supplying`
--
ALTER TABLE `supplying`
  MODIFY `SupplyingId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplyinginvoice`
--
ALTER TABLE `supplyinginvoice`
  MODIFY `InvoiceId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplyingprocess`
--
ALTER TABLE `supplyingprocess`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `fullreport`
--
ALTER TABLE `fullreport`
  ADD CONSTRAINT `FK_FullReport_Manager_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `manager` (`ManagerId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_FullReport_SupplyingInvoice_SupplyingInvoiceInvoiceId` FOREIGN KEY (`SupplyingInvoiceInvoiceId`) REFERENCES `supplyinginvoice` (`InvoiceId`);

--
-- Constraints for table `manager`
--
ALTER TABLE `manager`
  ADD CONSTRAINT `FK_Manager_Address_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `address` (`AddressId`) ON DELETE CASCADE;

--
-- Constraints for table `stockitems`
--
ALTER TABLE `stockitems`
  ADD CONSTRAINT `FK_StockItems_Supplying_SupplyingId` FOREIGN KEY (`SupplyingId`) REFERENCES `supplying` (`SupplyingId`) ON DELETE CASCADE;

--
-- Constraints for table `supplier`
--
ALTER TABLE `supplier`
  ADD CONSTRAINT `FK_Supplier_Manager_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `manager` (`ManagerId`) ON DELETE CASCADE;

--
-- Constraints for table `supplyinginvoice`
--
ALTER TABLE `supplyinginvoice`
  ADD CONSTRAINT `FK_SupplyingInvoice_Supplying_SupplyingId` FOREIGN KEY (`SupplyingId`) REFERENCES `supplying` (`SupplyingId`) ON DELETE CASCADE;

--
-- Constraints for table `supplyingprocess`
--
ALTER TABLE `supplyingprocess`
  ADD CONSTRAINT `FK_SupplyingProcess_Supplier_SupplierId` FOREIGN KEY (`SupplierId`) REFERENCES `supplier` (`SupplierId`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_SupplyingProcess_Supplying_SupplyingId` FOREIGN KEY (`SupplyingId`) REFERENCES `supplying` (`SupplyingId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
