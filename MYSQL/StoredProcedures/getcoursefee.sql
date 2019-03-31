USE `heroku_b33cb002ba86bd2`;
DROP procedure IF EXISTS `getcoursefee`;

DELIMITER $$
USE `heroku_b33cb002ba86bd2`$$
CREATE PROCEDURE `getcoursefee` (IN branchid INT)
begin
  IF ( branchid <> 0 ) THEN
    SELECT cf.id,
           cf.courseid,
           cf.branchid,
           b.branchname,
           c.coursename,
           cf.amount,
           cf.feestructure,
		   cf.credits
    FROM   coursefees cf
           INNER JOIN branchs b
                   ON cf.branchid = b.id
           INNER JOIN courses c
                   ON cf.courseid = c.id
    WHERE  cf.branchid = branchid;
  ELSE
    SELECT cf.id,
           cf.courseid,
           cf.branchid,
           b.branchname,
           c.coursename,
           cf.amount,
           cf.feestructure,
		   cf.credits
    FROM   coursefees cf
           INNER JOIN branchs b
                   ON cf.branchid = b.id
           INNER JOIN courses c
                   ON cf.courseid = c.id;
  end IF;
end$$

DELIMITER ;

