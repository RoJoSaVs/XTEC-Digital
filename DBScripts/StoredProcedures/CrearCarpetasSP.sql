--############################################################################--
GO
CREATE OR ALTER PROCEDURE CrearCarpetas (@grupo NVARCHAR(15)) AS
	BEGIN 
		BEGIN TRANSACTION
			SAVE TRANSACTION savePoint;
			BEGIN TRY
				INSERT INTO CARPETA(carpeta_id, nombre, ruta_url, grupo_id) VALUES
					(@grupo + 'PT','PRESENTACIONES', '/ingreso/presentaciones', @grupo),
					(@grupo + 'Q','QUICES', '/ingreso/quices', @grupo),
					(@grupo + 'E','EXAMENES', '/ingreso/examenes', @grupo),
					(@grupo + 'PY','PROYECTOS', '/ingreso/proyectos', @grupo);
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION savePoint;
			END CATCH;
	END;
GO

/*
INSERT INTO GRUPO(grupo_id, numero_grupo, cupo, anio, periodo, curso_id, profesor_id) VALUES
	('hola', 1, 24, 2020, '1', 'CE3101', '562856435684567');
select * from GRUPO;
select * from CARPETA;
DELETE FROM CARPETA WHERE grupo_id = 'HOLA';
DELETE FROM GRUPO WHERE grupo_id = 'HOLA';
EXEC CrearCarpetas @grupo = 'hola';
*/
--############################################################################--