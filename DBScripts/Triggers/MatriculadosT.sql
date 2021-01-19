--###############################################################--
/*CUENTA LA CANTIDAD DE ESTUDIANTES MATRICULADOS EN UN GRUPO*/
CREATE TRIGGER Matriculados ON ESTUDIANTE_GRUPO AFTER INSERT AS
	BEGIN
		SET NOCOUNT ON;
		DECLARE @grupo_matricula VARCHAR(15),
				@num_estudiantes INT;
		
		SET @grupo_matricula = (SELECT grupo_id FROM inserted);
		SET @num_estudiantes = (SELECT COUNT(*) FROM (ESTUDIANTE_GRUPO INNER JOIN GRUPO ON GRUPO.grupo_id = ESTUDIANTE_GRUPO.grupo_id));
		UPDATE GRUPO SET matriculados = @num_estudiantes WHERE grupo_id = @grupo_matricula;
		
	END;
/* ELEMENTOS PARA REALIZAR PRUEBAS DEL TRIGGER
DROP TRIGGER IF EXISTS Matriculados;
INSERT INTO ESTUDIANTE_GRUPO(estudiante_id, grupo_id) VALUES('2018109283', 'CE3101_1');
select * from GRUPO;
*/
--###############################################################--