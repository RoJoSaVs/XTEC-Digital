GO
CREATE OR ALTER PROCEDURE CrearNoticia (@grupo NVARCHAR(15), @titulo NVARCHAR(30), @mensaje VARCHAR(MAX), @autor NVARCHAR(15)) AS
	BEGIN 
		BEGIN TRANSACTION savePoint;
			--SAVE TRANSACTION savePoint;
			BEGIN TRY
				DECLARE @cant_noticias INT;
				SET @cant_noticias = (SELECT COUNT(*) FROM NOTICIA WHERE grupo_id = @grupo);
				INSERT INTO NOTICIA(noticia_id, titulo, mensaje, fecha, grupo_id, autor) VALUES
					(@grupo + '_N' + CONVERT(VARCHAR, @cant_noticias + 1), @titulo, @mensaje, GETDATE(), @grupo, @autor);
				COMMIT TRANSACTION; 
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION savePoint;
			END CATCH;
	END;
GO
/*
DROP PROCEDURE IF EXISTS CrearNoticia;
EXEC CrearNoticia @grupo = 'CE3101_1', @titulo = 'TEST', @mensaje = 'PRUEBA', @autor = '1111-1111';
DELETE FROM NOTICIA WHERE noticia_id = 'CE3101_1_N2'
SELECT * FROM NOTICIA
*/