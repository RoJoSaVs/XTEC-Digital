--############################################################################--
GO
CREATE OR ALTER PROCEDURE VerNoticias (@grupo NVARCHAR(15)) AS
	BEGIN
		BEGIN TRANSACTION
			BEGIN TRY
				SELECT * FROM NOTICIA WHERE grupo_id = @grupo ORDER BY fecha DESC;
				COMMIT TRANSACTION;
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION;
			END CATCH;
	END;
GO
/*
INSERT INTO GRUPO(grupo_id, numero_grupo, cupo, anio, periodo, curso_id, profesor_id) VALUES('aa', 1, 24, 2020, '1', 'CE3101', '562856435684567');
select * from GRUPO;
INSERT INTO NOTICIA(noticia_id, titulo, mensaje, fecha, autor, grupo_id) VALUES
	('aa1','Examen evaluado', 'en su examen obtuvo una nota de 98', '2021-01-17', 'Allan Calderon', 'aa'),
	('aa2','Fecha de examen', 'Su examen sera el dia jueves 12 de diciembre a las 3 pm, con duracion de 3 horas', '2020-12-04', 'Fabian Fallas','aa'),
	('aa3','Temas de examen', 'Los temas del examen son del capitulo 1 al 3', '2020-12-10', 'Elsie Garro', 'aa');
select * from NOTICIA;
DELETE FROM NOTICIA WHERE grupo_id = 'aa';
DELETE FROM GRUPO WHERE grupo_id = 'aa';
EXEC VerNoticias @grupo = 'aa';
*/