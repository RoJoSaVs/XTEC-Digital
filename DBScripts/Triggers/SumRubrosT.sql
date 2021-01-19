--###############################################################--
CREATE TRIGGER SumRubros ON RUBROS AFTER INSERT AS
	BEGIN
		SET NOCOUNT ON;

		DECLARE @sum_total INT,
				@grupo VARCHAR(15);

		SET @grupo = (SELECT grupo_id FROM inserted);
		SET @sum_total = (SELECT SUM(RUBROS.porcentaje) FROM RUBROS WHERE RUBROS.grupo_id = @grupo GROUP BY (RUBROS.grupo_id));
		IF (@sum_total > 100)
			BEGIN
				RAISERROR('LOS RUBROS NO PUEDEN SUMAR MAS DE 100', 10, 1);
				ROLLBACK;
			END;
	END;
/* ELEMENTOS PARA REALIZAR PRUEBAS DEL TRIGGER
DROP TRIGGER IF EXISTS SumRubros;
INSERT INTO RUBROS(rubro_id, nombre, porcentaje, grupo_id) VALUES('test', 'Extra', 10, 'CE3101_1');
DELETE FROM RUBROS WHERE rubro_id = 'test';
select * from RUBROS;
*/
--###############################################################--