-- =========================
-- DATOS INICIALES
-- PROGRAMA FORMACION
-- =========================

INSERT INTO ProgramaFormacion(NombrePrograma)
VALUES('ANALISIS Y DESARROLLO DE SOFTWARE'),
('CONTABILIDAD'),
('LOGISTICA EMPRESARIAL'),
('GESTION ADMINISTRATIVA'),
('MANTENIMIENTO INDUSTRIAL');

INSERT INTO ProgramaFormacion(NombrePrograma)
VALUES ('ADMINISTRACION SISTEMA');

SELECT * FROM ProgramaFormacion;

-- =========================
-- TIPO EVENTO
-- =========================

INSERT INTO TipoEvento(NombreTipoEvento)
VALUES ('ACADEMICO');

INSERT INTO TipoEvento(NombreTipoEvento)
VALUES ('DEPORTIVO');

INSERT INTO TipoEvento(NombreTipoEvento)
VALUES ('CULTURAL');

SELECT * FROM TipoEvento;

-- =========================
-- ADMINISTRADORES DEL SISTEMA
-- =========================

INSERT INTO Usuario
(idProgramaFormacion, TipoDocumento, NumeroDocumento, NombreCompleto, Correo, Ficha, Jornada, Rol, FechaRegistro, Contrasena)
VALUES
(6, 'CC', '1048442056', 'Leider Maza Taboada', 'leider.maza@soy.sena.edu.co', 'ADMIN', 'ADMINISTRATIVA', 'ADMIN', GETDATE(), '123456');

INSERT INTO Usuario
(idProgramaFormacion, TipoDocumento, NumeroDocumento, NombreCompleto, Correo, Ficha, Jornada, Rol, FechaRegistro, Contrasena)
VALUES
(6, 'CC', '1043456782', 'Alejandro Vera', 'alejandro.vera@soy.sena.edu.co', 'ADMIN', 'ADMINISTRATIVA', 'ADMIN', GETDATE(), '123456');

INSERT INTO Usuario
(idProgramaFormacion, TipoDocumento, NumeroDocumento, NombreCompleto, Correo, Ficha, Jornada, Rol, FechaRegistro, Contrasena)
VALUES
(6, 'CC', '1048554459', 'Leider Manuel Diaz', 'leider.diaz@soy.sena.edu.co', 'ADMIN', 'ADMINISTRATIVA', 'ADMIN', GETDATE(), '123456');

SELECT * FROM Usuario;

-- =========================
-- EVENTOS DE PRUEBA
-- =========================

INSERT INTO Evento
(idTipoEvento, NombreEvento, Descripcion, Modalidad, Lugar, FechaEvento,
HoraInicio, HoraFin, CuposTotales, FechaInicioInscripcion,
FechaFinInscripcion, Activo, FechaCreacion)
VALUES
(
    1,'Conferencia de Inteligencia Artificial','Evento academico sobre IA y nuevas tecnologias','INDIVIDUAL','Auditorio Principal','2026-06-20','08:00','12:00',50,'2026-06-10','2026-06-18',1,GETDATE()
);

INSERT INTO Evento
(idTipoEvento, NombreEvento, Descripcion, Modalidad, Lugar, FechaEvento,
HoraInicio, HoraFin, CuposTotales, FechaInicioInscripcion,
FechaFinInscripcion, Activo, FechaCreacion)
VALUES
(
    2,'Torneo Futbol SENA','Competencia deportiva por equipos','EQUIPO','Cancha Principal','2026-06-25','07:00','17:00',30,'2026-06-10','2026-06-22',1,GETDATE()
);

INSERT INTO Evento
(idTipoEvento, NombreEvento, Descripcion, Modalidad, Lugar, FechaEvento,
HoraInicio, HoraFin, CuposTotales, FechaInicioInscripcion,
FechaFinInscripcion, Activo, FechaCreacion)
VALUES
(
    3,'Festival Cultural SENA','Muestras artisticas y culturales','INDIVIDUAL','Plaza Central','2026-06-28','14:00','18:00',100,'2026-06-10','2026-06-26',1,GETDATE()
);
SELECT * FROM Evento;

-- =========================
-- EQUIPOS TORNEO FUTBOL SENA
-- =========================

INSERT INTO Equipo(idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
VALUES (2, 'Equipo A', 3, 5);

INSERT INTO Equipo(idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
VALUES (2, 'Equipo B', 3, 5);

INSERT INTO Equipo(idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
VALUES (2, 'Equipo C', 3, 5);

INSERT INTO Equipo(idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
VALUES (2, 'Equipo D', 3, 5);

INSERT INTO Equipo(idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
VALUES (2, 'Equipo E', 3, 5);

INSERT INTO Equipo(idEvento, NombreEquipo, CantidadMinima, CantidadMaxima)
VALUES (2, 'Equipo F', 3, 5);

SELECT * FROM Equipo;