/*Muestra las notas de los estudiantes pertenecientes a un grupo*/
GO
CREATE OR ALTER PROCEDURE VerNotasProfesor (@grupo_id NVARCHAR(15)) AS
	BEGIN
		BEGIN TRANSACTION
			SAVE TRANSACTION savePoint;
			BEGIN TRY
				SELECT SUB_GRUPO.estudiante_id as 'Carnet', RUBROS.nombre 'Rubro', RUBROS.porcentaje as 'PorcentajeDelRubro', 
				ENTREGABLE.nota as 'Nota' ,EVALUACION.nombre as 'NombreDeEvaluacion' , EVALUACION.porcentaje as 'PorcentajeDeEvaluacion'
				FROM (((SUB_GRUPO INNER JOIN ENTREGABLE ON SUB_GRUPO.entregable_id = ENTREGABLE.entregable_id) 
					INNER JOIN EVALUACION ON EVALUACION.evaluacion_id = ENTREGABLE.evaluacion_id)
					INNER JOIN RUBROS ON RUBROS.rubro_id = EVALUACION.rubro_id)
					WHERE SUB_GRUPO.grupo_id = @grupo_id;
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION savePoint;
			END CATCH;
	END;
GO
/*
EXEC VerNotasProfesor @grupo_id = ce3101_1;
DROP PROCEDURE VerNotasProfesor
*/