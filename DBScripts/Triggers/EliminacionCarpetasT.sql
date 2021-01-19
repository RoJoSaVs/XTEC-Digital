--###############################################################--
/*EVITA QUE SE BORREN LAS CARPETAS INICIALES (EXAMENES, PRESENTACIONES, QUICES Y PROYECTOS)*/
CREATE TRIGGER EliminacionCarpetas ON CARPETA FOR DELETE AS
	BEGIN
		SET NOCOUNT ON;
		DECLARE @nombre_carpeta VARCHAR(15),
				@grupo VARCHAR(15);

		SET @nombre_carpeta = (SELECT nombre FROM deleted);
		SET @grupo = (SELECT grupo_id FROM deleted);
		IF EXISTS(SELECT * FROM GRUPO WHERE grupo_id = @grupo)
			BEGIN
				IF((@nombre_carpeta = 'EXAMENES') OR (@nombre_carpeta = 'PRESENTACIONES') OR (@nombre_carpeta = 'QUICES') OR (@nombre_carpeta = 'PROYECTOS'))
					BEGIN
						PRINT('NO SE PUEDE ELIMINAR LA CARPETA ' + @nombre_carpeta);
						ROLLBACK;	
					END;
			END;
	END;


/* ELEMENTOS PARA REALIZAR PRUEBAS DEL TRIGGER
DROP TRIGGER IF EXISTS EliminacionCarpetas;
select * from CARPETA;
DELETE FROM CARPETA WHERE carpeta_id = 'hola'
INSERT INTO CARPETA(carpeta_id, nombre, ruta_url, grupo_id) VALUES('hola','test', '/ingreso/presentaciones', 'CE3101_1')
*/
--###############################################################--