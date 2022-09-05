--Color
INSERT INTO COLOR (Nombre) VALUES ('blanco')
--Marca
insert into Marca (Nombre) values ('toyota')
--Personas
insert into Persona (Rut, Dv, Nombres, Apellidos, Correo, Password) 
values (16268294, '6', 'claudio ivan', 'vargas lillo', 'claudio@gmail.com', '123')
--Vehiculo
insert into Vehiculo (Modelo, MarcaId, ColorId, PersonaId)
values ('FJ cruiser', 1, 1, 1)
--Tipo
insert into Tipo (Nombre) values ('encerrona')
--Ubicacion
insert into Ubicacion (Pais, Region, Localidad, Comuna, Direccion) values ('chile', 'metropolitana', 'metropolitana', 'maipu', 'las tacas oriente 227')
--Roo 
insert into Robo (PersonaId, TipoRoboId, UbicacionId,  fecha, fechaModificacion) values (1, 1, 1, '2022-01-01', '2022-01-01')

select * from Color
select * from Marca
select * from Persona
select * from Vehiculo
select * from Tipo
select * from Ubicacion
select * from Robo
