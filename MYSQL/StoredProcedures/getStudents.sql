USE `heroku_b33cb002ba86bd2`;
DROP procedure IF EXISTS `getcoursefee`;

DELIMITER $$
USE `heroku_b33cb002ba86bd2`$$
CREATE PROCEDURE `getcoursefee` (IN branchid INT)
begin
  IF ( branchid <> 0 ) THEN
    SELECT * FROM   students s;
  ELSE
    SELECT * FROM   students s;
  end IF;
end$$

DELIMITER ;

