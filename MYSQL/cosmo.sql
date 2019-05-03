-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'Users'
-- 
-- ---

DROP TABLE IF EXISTS `Users`;
		
CREATE TABLE `Users` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `UserName` VARCHAR(100) NOT NULL,
  `Password` VARCHAR(100) NOT NULL,
  `Email` VARCHAR(100) NOT NULL,
  `ProfilePic` VARCHAR(500) NULL DEFAULT NULL,
  `BranchId` INTEGER NOT NULL,
  `UserRoleId` INTEGER NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'UserRoles'
-- 
-- ---

DROP TABLE IF EXISTS `UserRoles`;
		
CREATE TABLE `UserRoles` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `UserRole` VARCHAR(100) NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Branchs'
-- 
-- ---

DROP TABLE IF EXISTS `Branchs`;
		
CREATE TABLE `Branchs` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `BranchName` VARCHAR(200) NOT NULL,
  `BranchAddress` VARCHAR(500) NOT NULL,
  `ContactNumber` VARCHAR(15) NOT NULL,
  `ContactPerson` VARCHAR(100) NULL DEFAULT NULL,
  `BranchEmail` VARCHAR(50) NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `IsMain` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Courses'
-- 
-- ---

DROP TABLE IF EXISTS `Courses`;
		
CREATE TABLE `Courses` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `CourseName` VARCHAR(100) NOT NULL,
  `Description` VARCHAR(500) NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Batchs'
-- 
-- ---

DROP TABLE IF EXISTS `Batchs`;
		
CREATE TABLE `Batchs` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `BatchName` VARCHAR(20) NOT NULL,
  `Description` VARCHAR(500) NULL DEFAULT NULL,
  `BranchId` INTEGER NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'BatchAssignments'
-- 
-- ---

DROP TABLE IF EXISTS `BatchAssignments`;
		
CREATE TABLE `BatchAssignments` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `BranchId` INTEGER NULL DEFAULT NULL,
  `CourseId` INTEGER NOT NULL,
  `BatchId` INTEGER NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Staffs'
-- 
-- ---

DROP TABLE IF EXISTS `Staffs`;
		
CREATE TABLE `Staffs` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `StaffRoleId` INTEGER NOT NULL,
  `Name` VARCHAR(100) NOT NULL,
  `Address` VARCHAR(300) NOT NULL,
  `ContactNumber` VARCHAR(15) NOT NULL,
  `Email` VARCHAR(100) NOT NULL,
  `BranchId` INTEGER NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'StaffRoles'
-- 
-- ---

DROP TABLE IF EXISTS `StaffRoles`;
		
CREATE TABLE `StaffRoles` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `StaffRole` VARCHAR(200) NOT NULL,
  `Description` VARCHAR(200) NULL DEFAULT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Students'
-- 
-- ---

DROP TABLE IF EXISTS `Students`;
		
CREATE TABLE `Students` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `StudentName` VARCHAR(100) NOT NULL,
  `ContactNumber` VARCHAR(15) NOT NULL,
  `Email` VARCHAR(100) NOT NULL,
  `Address` VARCHAR(300) NULL DEFAULT NULL,
  `Gender` VARCHAR NOT NULL,
  `BranchId` INTEGER NOT NULL,
  `QualificationId` INTEGER NULL DEFAULT NULL,
  `ProfessionId` INTEGER NULL DEFAULT NULL,
  `SourceId` INTEGER NULL DEFAULT NULL,
  `FeesPaid` INTEGER NULL DEFAULT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'StudentAssignments'
-- 
-- ---

DROP TABLE IF EXISTS `StudentAssignments`;
		
CREATE TABLE `StudentAssignments` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `BatchAssignId` INTEGER NOT NULL,
  `StudentId` INTEGER NOT NULL,
  `CourseFeeId` INTEGER NOT NULL,
  `ReceiptId` INTEGER NULL DEFAULT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'CourseFees'
-- 
-- ---

DROP TABLE IF EXISTS `CourseFees`;
		
CREATE TABLE `CourseFees` (
  `Id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `FeeStructure` VARCHAR(100) NOT NULL,
  `Amount` DECIMAL NOT NULL,
  `CourseId` INTEGER NOT NULL,
  `BranchId` INTEGER NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `Credits` INTEGER NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Receipts'
-- 
-- ---

DROP TABLE IF EXISTS `Receipts`;
		
CREATE TABLE `Receipts` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `AmountPaid` DECIMAL NOT NULL,
  `PaymentMethodId` INTEGER NOT NULL,
  `Reference` VARCHAR(200) NULL DEFAULT NULL,
  `ReceiptDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `BranchId` INTEGER NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'PaymentMethods'
-- 
-- ---

DROP TABLE IF EXISTS `PaymentMethods`;
		
CREATE TABLE `PaymentMethods` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `PaymentMethod` VARCHAR(100) NOT NULL,
  `BranchId` INTEGER NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Professions'
-- 
-- ---

DROP TABLE IF EXISTS `Professions`;
		
CREATE TABLE `Professions` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Profession` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Sources'
-- 
-- ---

DROP TABLE IF EXISTS `Sources`;
		
CREATE TABLE `Sources` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Source` VARCHAR(250) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Qualifications'
-- 
-- ---

DROP TABLE IF EXISTS `Qualifications`;
		
CREATE TABLE `Qualifications` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Qualification` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Enquiry'
-- 
-- ---

DROP TABLE IF EXISTS `Enquiry`;
		
CREATE TABLE `Enquiry` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(250) NOT NULL,
  `ContactNumber` VARCHAR(15) NOT NULL,
  `Address` VARCHAR(250) NOT NULL,
  `CourseId` INTEGER NULL DEFAULT NULL,
  `BranchId` INTEGER NOT NULL,
  `Remarks` VARCHAR(250) NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'ExpenseHead'
-- 
-- ---

DROP TABLE IF EXISTS `ExpenseHead`;
		
CREATE TABLE `ExpenseHead` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(250) NOT NULL,
  `Description` VARCHAR(500) NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Expense'
-- 
-- ---

DROP TABLE IF EXISTS `Expense`;
		
CREATE TABLE `Expense` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Description` VARCHAR(500) NOT NULL,
  `ExpenseHeadId` INTEGER NOT NULL,
  `Amount` DECIMAL NOT NULL,
  `Reference` VARCHAR(100) NULL DEFAULT NULL,
  `BranchId` INTEGER NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'IncomeHead'
-- 
-- ---

DROP TABLE IF EXISTS `IncomeHead`;
		
CREATE TABLE `IncomeHead` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(250) NOT NULL,
  `Description` VARCHAR(500) NULL DEFAULT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Income'
-- 
-- ---

DROP TABLE IF EXISTS `Income`;
		
CREATE TABLE `Income` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `Description` VARCHAR(250) NOT NULL,
  `IncomeHeadId` INTEGER NOT NULL,
  `Amount` DECIMAL NOT NULL DEFAULT 0,
  `Reference` VARCHAR(100) NULL DEFAULT NULL,
  `BranchId` INTEGER NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Foreign Keys 
-- ---

ALTER TABLE `Users` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `Users` ADD FOREIGN KEY (UserRoleId) REFERENCES `UserRoles` (`Id`);
ALTER TABLE `Courses` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Courses` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Batchs` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `Batchs` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Batchs` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `BatchAssignments` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `BatchAssignments` ADD FOREIGN KEY (CourseId) REFERENCES `Courses` (`Id`);
ALTER TABLE `BatchAssignments` ADD FOREIGN KEY (BatchId) REFERENCES `Batchs` (`Id`);
ALTER TABLE `BatchAssignments` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `BatchAssignments` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Staffs` ADD FOREIGN KEY (StaffRoleId) REFERENCES `StaffRoles` (`Id`);
ALTER TABLE `Staffs` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `Staffs` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Staffs` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `StaffRoles` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `StaffRoles` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Students` ADD FOREIGN KEY (QualificationId) REFERENCES `Qualifications` (`Id`);
ALTER TABLE `Students` ADD FOREIGN KEY (ProfessionId) REFERENCES `Professions` (`Id`);
ALTER TABLE `Students` ADD FOREIGN KEY (SourceId) REFERENCES `Sources` (`Id`);
ALTER TABLE `Students` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Students` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (BatchAssignId) REFERENCES `BatchAssignments` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (StudentId) REFERENCES `Students` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (StudentId) REFERENCES `Students` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (CourseFeeId) REFERENCES `CourseFees` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (ReceiptId) REFERENCES `Receipts` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `StudentAssignments` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `CourseFees` ADD FOREIGN KEY (CourseId) REFERENCES `Courses` (`Id`);
ALTER TABLE `CourseFees` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `CourseFees` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `CourseFees` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Receipts` ADD FOREIGN KEY (PaymentMethodId) REFERENCES `PaymentMethods` (`Id`);
ALTER TABLE `Receipts` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Receipts` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Receipts` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Receipts` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `PaymentMethods` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `PaymentMethods` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `PaymentMethods` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Enquiry` ADD FOREIGN KEY (CourseId) REFERENCES `Courses` (`Id`);
ALTER TABLE `Enquiry` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `Enquiry` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Enquiry` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `ExpenseHead` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `ExpenseHead` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Expense` ADD FOREIGN KEY (ExpenseHeadId) REFERENCES `ExpenseHead` (`Id`);
ALTER TABLE `Expense` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `Expense` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Expense` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `IncomeHead` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `IncomeHead` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Income` ADD FOREIGN KEY (IncomeHeadId) REFERENCES `IncomeHead` (`Id`);
ALTER TABLE `Income` ADD FOREIGN KEY (BranchId) REFERENCES `Branchs` (`Id`);
ALTER TABLE `Income` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Income` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `Users` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `UserRoles` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Branchs` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Courses` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Batchs` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `BatchAssignments` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Staffs` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `StaffRoles` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Students` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `StudentAssignments` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `CourseFees` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Receipts` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `PaymentMethods` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Professions` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Sources` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Qualifications` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Enquiry` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `ExpenseHead` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Expense` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `IncomeHead` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Income` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `Users` (`Id`,`UserName`,`Password`,`Email`,`ProfilePic`,`BranchId`,`UserRoleId`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','','','','');
-- INSERT INTO `UserRoles` (`Id`,`UserRole`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','');
-- INSERT INTO `Branchs` (`Id`,`BranchName`,`BranchAddress`,`ContactNumber`,`ContactPerson`,`BranchEmail`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`,`IsMain`) VALUES
-- ('','','','','','','','','','','');
-- INSERT INTO `Courses` (`Id`,`CourseName`,`Description`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','');
-- INSERT INTO `Batchs` (`Id`,`BatchName`,`Description`,`BranchId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','');
-- INSERT INTO `BatchAssignments` (`Id`,`BranchId`,`CourseId`,`BatchId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','');
-- INSERT INTO `Staffs` (`Id`,`StaffRoleId`,`Name`,`Address`,`ContactNumber`,`Email`,`BranchId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','','','','');
-- INSERT INTO `StaffRoles` (`Id`,`StaffRole`,`Description`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','');
-- INSERT INTO `Students` (`Id`,`StudentName`,`ContactNumber`,`Email`,`Address`,`Gender`,`BranchId`,`QualificationId`,`ProfessionId`,`SourceId`,`FeesPaid`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','','','','','','','','');
-- INSERT INTO `StudentAssignments` (`Id`,`BatchAssignId`,`StudentId`,`CourseFeeId`,`ReceiptId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','','');
-- INSERT INTO `CourseFees` (`Id`,`FeeStructure`,`Amount`,`CourseId`,`BranchId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`,`Credits`) VALUES
-- ('','','','','','','','','','');
-- INSERT INTO `Receipts` (`Id`,`AmountPaid`,`PaymentMethodId`,`Reference`,`ReceiptDate`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`,`BranchId`) VALUES
-- ('','','','','','','','','','');
-- INSERT INTO `PaymentMethods` (`Id`,`PaymentMethod`,`BranchId`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','');
-- INSERT INTO `Professions` (`Id`,`Profession`) VALUES
-- ('','');
-- INSERT INTO `Sources` (`Id`,`Source`) VALUES
-- ('','');
-- INSERT INTO `Qualifications` (`Id`,`Qualification`) VALUES
-- ('','');
-- INSERT INTO `Enquiry` (`Id`,`Name`,`ContactNumber`,`Address`,`CourseId`,`BranchId`,`Remarks`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','','','','');
-- INSERT INTO `ExpenseHead` (`Id`,`Name`,`Description`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','');
-- INSERT INTO `Expense` (`Id`,`Description`,`ExpenseHeadId`,`Amount`,`Reference`,`BranchId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedBy`) VALUES
-- ('','','','','','','','','','');
-- INSERT INTO `IncomeHead` (`Id`,`Name`,`Description`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','');
-- INSERT INTO `Income` (`Id`,`Description`,`IncomeHeadId`,`Amount`,`Reference`,`BranchId`,`CreatedBy`,`UpdatedBy`,`CreatedDate`,`UpdatedDate`) VALUES
-- ('','','','','','','','','','');