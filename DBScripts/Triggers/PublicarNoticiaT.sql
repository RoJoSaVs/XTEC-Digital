--###############################################################--
/*AGREGA UNA NOTICIA CUANDO SE PUBLICA LA NOTA DE UN ENTREGABLE*/
CREATE TRIGGER PublicarNoticia ON ENTREGABLE FOR UPDATE AS
	BEGIN
		SET NOCOUNT ON;

		DECLARE @num_news INT,
				@evaluacion VARCHAR(30),
				@grupo VARCHAR(15);

		SET @grupo = (SELECT RUBROS.grupo_id from ((inserted INNER JOIN EVALUACION ON inserted.evaluacion_id = EVALUACION.evaluacion_id) 
						INNER JOIN RUBROS ON EVALUACION.rubro_id = RUBROS.rubro_id));
		SET @num_news = (SELECT COUNT(*) FROM NOTICIA WHERE	grupo_id = @grupo);
		SET @evaluacion = (SELECT EVALUACION.nombre FROM 
							(inserted INNER JOIN EVALUACION ON inserted.evaluacion_id = EVALUACION.evaluacion_id));
		IF((SELECT PUBLICO FROM inserted) = 1)
			BEGIN
				INSERT INTO NOTICIA(noticia_id, titulo, mensaje, fecha, autor, grupo_id) VALUES
				(@grupo + '_N' + CONVERT(VARCHAR, @num_news + 1 ), 'Nota publicada', 'Se le informa que la nota correspondiente a: ' + @evaluacion + ' ya está disponible', GETDATE(), 'iwachu', @grupo);
			END;
	END;

/* ELEMENTOS PARA REALIZAR PRUEBAS DEL TRIGGER
DROP TRIGGER IF EXISTS PublicarNoticia;
UPDATE ENTREGABLE SET publico = 1 WHERE entregable_id = 'FI3454_3E_E2';
*/