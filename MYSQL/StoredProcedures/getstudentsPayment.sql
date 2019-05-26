USE `heroku_b33cb002ba86bd2`;

DROP PROCEDURE

IF EXISTS `getstudentspayment`;
	DELIMITER $$

USE `heroku_b33cb002ba86bd2`$$

CREATE PROCEDURE `getstudentspayment` (
	IN branchid INT
	)

BEGIN
	IF (branchid <> 0) THEN
		SELECT st.StudentName,cf.Amount,cf.FeeStructure,b.BatchName,c.CourseName, false as IsPaid
		FROM students st
		INNER JOIN studentassignments sa ON st.id = sa.StudentId
        INNER JOIN coursefees cf ON sa.CourseFeeId = cf.id
        INNER JOIN courses c ON c.id = cf.CourseId
        INNER JOIN batchassignments ba on ba.id = sa.BatchAssignId
        INNER JOIN batchs b on ba.batchId = b.id
		WHERE i.branchid = branchid;
	ELSE
		SELECT st.StudentName,cf.Amount,cf.FeeStructure,b.BatchName,c.CourseName, false as IsPaid
		FROM students st
		INNER JOIN studentassignments sa ON st.id = sa.StudentId
        INNER JOIN coursefees cf ON sa.CourseFeeId = cf.id
        INNER JOIN courses c ON c.id = cf.CourseId
        INNER JOIN batchassignments ba on ba.id = sa.BatchAssignId
        INNER JOIN batchs b on ba.batchId = b.id;
END

IF ;
	end$$ 

DELIMITER ;
