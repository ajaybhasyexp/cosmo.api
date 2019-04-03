USE `heroku_b33cb002ba86bd2`;DROP PROCEDURE 
IF EXISTS `getStudentAssignments`;DELIMITER $$ 
  USE `heroku_b33cb002ba86bd2`$$ 
  CREATE PROCEDURE 
    `getStudentAssignments` (IN branchid INT) 
  begin 
    IF ( branchid <> 0 ) THEN 
      SELECT     s.studentid, 
                 c.coursename, 
                 s.batchassignid, 
                 s.coursefeeid, 
                 st.studentname, 
                 b.batchname, 
                 (cf.feestructure + ' - ' + cf.amount) AS feestructurename 
      FROM       studentassignments s 
      INNER JOIN batchassignments ba 
      ON         s.batchassignid = ba.id 
      INNER JOIN batchs b 
      ON         ba.batchid = b.id 
      INNER JOIN courses c 
      ON         ba.courseid = c.id 
      INNER JOIN coursefees cf 
      ON         s.coursefeeid = cf.id 
      INNER JOIN students st 
      ON         s.studentid = st.id 
      WHERE      st.branchid = branchid;delimiter ;