--##########################################################################################################--
GO
CREATE VIEW VerNoticiasV AS
	SELECT N.titulo, N.autor, N.fecha, N.mensaje, G.curso_id, G.numero_grupo, G.grupo_id
	FROM NOTICIA AS N INNER JOIN GRUPO AS G ON N.grupo_id = G.grupo_id;
GO
/*
SELECT * FROM VerNoticiasV WHERE GRUPO_ID = 'CE3101_1';
SELECT * FROM NOTICIA;
SELECT * FROM GRUPO;
DROP VIEW VerNoticiasV;
*/
--##########################################################################################################--