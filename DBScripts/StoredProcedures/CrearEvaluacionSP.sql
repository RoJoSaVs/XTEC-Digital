--############################################################################--
GO
CREATE OR ALTER PROCEDURE CrearEvaluacion (@grupo NVARCHAR(15)) AS
	BEGIN 
		BEGIN TRANSACTION
			--SAVE TRANSACTION savePointEvaluaciones;
			BEGIN TRY
				INSERT INTO RUBROS(rubro_id, nombre, porcentaje, grupo_id) VALUES
					(@grupo + 'Q', 'Quices', 30, @grupo),
					(@grupo + 'E', 'Examenes', 30, @grupo),
					(@grupo + 'P', 'Proyectos', 40, @grupo);
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION;-- savePointEvaluaciones;
			END CATCH;
	END;
GO
/*
INSERT INTO GRUPO(grupo_id, numero_grupo, cupo, anio, periodo, curso_id, profesor_id) VALUES('hola', 1, 24, 2020, '1', 'CE3101', '562856435684567');
select * from GRUPO;
select * from rubros;
SELECT * FROM RUBROS WHERE grupo_id = 'HOLA';
DELETE FROM GRUPO WHERE grupo_id = 'HOLA';
DELETE FROM RUBROS WHERE grupo_id = 'HOLA';
EXEC CrearEvaluacion @grupo = 'hola';
*/
--############################################################################--