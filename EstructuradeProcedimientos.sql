create procedure PR_LOGIN
@Nombre varchar(50),
@Clave varchar(50)
as
select * from Usuario 
where nombre = @Nombre and clave = @Clave
go

create procedure PR_LISTAR_CURSOS
as
select * from Curso
order by nombre
go

create procedure PR_REGISTRAR_CURSO
@Nombre varchar(50),
@Correo varchar(50),
@NumCreditos int
as
-- Validamos que no exista el curso a través del nombre
if not exists(select * from curso where nombre = @Nombre)
insert into Curso (nombre, correo, credito) values (@Nombre,@Correo,@NumCreditos)
go