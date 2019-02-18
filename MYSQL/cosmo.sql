-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'User'
-- 
-- ---

DROP TABLE IF EXISTS `User`;
		
CREATE TABLE `User` (
  `UserId` INTEGER NOT NULL AUTO_INCREMENT,
  `UserName` VARCHAR(50) NOT NULL,
  `Password` VARCHAR(500) NOT NULL,
  `Email` VARCHAR(200) NOT NULL,
  `Token` VARCHAR(300) NULL DEFAULT NULL,
  `UserRoleId` INTEGER NOT NULL,
  `BranchId` INTEGER NOT NULL,
  PRIMARY KEY (`UserId`)
);

-- ---
-- Table 'UserRole'
-- 
-- ---

DROP TABLE IF EXISTS `UserRole`;
		
CREATE TABLE `UserRole` (
  `UserRoleId` INTEGER NOT NULL AUTO_INCREMENT,
  `UserRoleName` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`UserRoleId`)
);

-- ---
-- Table 'Branch'
-- 
-- ---

DROP TABLE IF EXISTS `Branch`;
		
CREATE TABLE `Branch` (
  `BranchId` INTEGER NOT NULL AUTO_INCREMENT,
  `BranchName` VARCHAR(100) NOT NULL,
  `BranchAddress` VARCHAR(500) NOT NULL,
  `ContactPerson` VARCHAR(100) NULL DEFAULT NULL,
  `ContactNumber` VARCHAR(15) NULL DEFAULT NULL,
  `AlternativeContact` VARCHAR(15) NULL DEFAULT NULL,
  PRIMARY KEY (`BranchId`)
);

-- ---
-- Foreign Keys 
-- ---

ALTER TABLE `User` ADD FOREIGN KEY (UserRoleId) REFERENCES `UserRole` (`UserRoleId`);
ALTER TABLE `User` ADD FOREIGN KEY (BranchId) REFERENCES `Branch` (`BranchId`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `User` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `UserRole` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Branch` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `User` (`UserId`,`UserName`,`Password`,`Email`,`Token`,`UserRoleId`,`BranchId`) VALUES
-- ('','','','','','','');
-- INSERT INTO `UserRole` (`UserRoleId`,`UserRoleName`) VALUES
-- ('','');
-- INSERT INTO `Branch` (`BranchId`,`BranchName`,`BranchAddress`,`ContactPerson`,`ContactNumber`,`AlternativeContact`) VALUES
-- ('','','','','','');