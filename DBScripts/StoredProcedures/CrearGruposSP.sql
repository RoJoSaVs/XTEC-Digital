--############################################################################--
/*AGREGA UN GRUPO A LA BASE DE DATOS*/
GO
CREATE OR ALTER PROCEDURE CrearGrupos (@curso NVARCHAR(15), @num_grupo INT, @cupo INT, @anio INT, @periodo CHAR(1), @profesor NVARCHAR(15)) AS
	BEGIN
		BEGIN TRANSACTION
			BEGIN TRY
				DECLARE @grupo_id VARCHAR(15);
			
				SET @grupo_id = (@curso + '_' + CONVERT(VARCHAR, @num_grupo) + '_' + CONVERT(VARCHAR, @periodo) + '_' + CONVERT(VARCHAR(4), @anio));
				INSERT INTO GRUPO(grupo_id, numero_grupo, cupo, anio, periodo, curso_id, profesor_id) VALUES
					(@grupo_id, @num_grupo, @cupo, @anio, @periodo, @curso, @profesor);
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION;
			END CATCH;
	END;
GO

--EXEC CrearGrupos @curso = 'CE3101', @num_grupo = 3, @cupo = 40, @anio = 2020, @periodo = 'V', @profesor = '562856435684567';
--############################################################################--