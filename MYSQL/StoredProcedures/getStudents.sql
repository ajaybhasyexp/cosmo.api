USE `heroku_b33cb002ba86bd2`;DROP PROCEDURE 
IF EXISTS `getStudents`;DELIMITER $$ 
  USE `heroku_b33cb002ba86bd2`$$ 
  CREATE PROCEDURE 
    `getStudents` (IN branchid INT) 
  begin 
    IF ( branchid <> 0 ) THEN 
      SELECT     s.*, 
                 q.qualificationname, 
                 so.sourcename, 
                 p.professionname 
      FROM       students s 
      INNER JOIN qualifications q 
      ON         s.qualificationid = q.id 
      INNER JOIN sources so 
      ON         s.sourceid = so.id 
      INNER JOIN professions p 
      ON         s.professionid = p.id 
      WHERE      s.branchid = branchid;ELSE 
      SELECT * 
      FROM   students s;END IF;end$$ 
    delimiter ;