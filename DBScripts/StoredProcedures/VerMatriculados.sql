/*Muestra los estudiantes matriculados en un curso*/
GO 
CREATE OR ALTER PROCEDURE VerMatriculados (@curso_id NVARCHAR(15)) AS
	BEGIN
		BEGIN TRANSACTION savePoint;
			--SAVE TRANSACTION savePoint;
			BEGIN TRY
				--SELECT EC.estudiante_id, C.codigo, C.nombre FROM (ESTUDIANTE_CURSO AS EC INNER JOIN CURSO C ON EC.curso_id = C.codigo)
				SELECT EC.estudiante_id FROM (ESTUDIANTE_CURSO AS EC INNER JOIN CURSO C ON EC.curso_id = C.codigo)				
				WHERE C.codigo = @curso_id;
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION savePoint;
			END CATCH;
	END;
GO
/*
EXEC VerMatriculados @curso_id = 'CE3101';
EXEC VerMatriculados @curso_id = 'CE4101';
DROP PROCEDURE VerMatriculados
*/