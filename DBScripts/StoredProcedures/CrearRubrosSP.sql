GO
CREATE OR ALTER PROCEDURE CrearRubros (@grupo NVARCHAR(15), @nombre NVARCHAR(30), @porcentaje INT) AS
	BEGIN 
		BEGIN TRANSACTION
			SAVE TRANSACTION savePoint;
			BEGIN TRY
				DECLARE @cant_rubros INT;
				SET @cant_rubros = (SELECT COUNT(*) FROM RUBROS WHERE grupo_id = @grupo);
				INSERT INTO RUBROS(rubro_id, nombre, porcentaje, grupo_id) VALUES
					(@grupo + '_R' + CONVERT(VARCHAR, @cant_rubros), @nombre, @porcentaje, @grupo);
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION savePoint;
			END CATCH;
	END;
GO
/*
EXEC CrearRubros @grupo = 'CE3101_1', @nombre = 'TEST', @porcentaje = 10;	
DELETE FROM RUBROS WHERE rubro_id = 'CE3101_1_R3';
select * from RUBROS;
select * from RUBROS where grupo_id = 'CE3101_1';
*/