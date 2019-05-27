-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.5.48-log - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             10.0.0.5460
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para babershop
CREATE DATABASE IF NOT EXISTS `babershop` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `babershop`;

-- Volcando estructura para tabla babershop.barberia
CREATE TABLE IF NOT EXISTS `barberia` (
  `idbarberia` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  `fk_idPropietario` int(11) NOT NULL,
  PRIMARY KEY (`idbarberia`),
  KEY `fk_barberia_Propietario1_idx` (`fk_idPropietario`),
  CONSTRAINT `fk_barberia_Propietario1` FOREIGN KEY (`fk_idPropietario`) REFERENCES `propietario` (`idPropietario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.barberia: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `barberia` DISABLE KEYS */;
INSERT INTO `barberia` (`idbarberia`, `nombre`, `direccion`, `estado`, `fk_idPropietario`) VALUES
	(2, 'victorresbabershop', 'cr1 # 4a 05', 'A', 3),
	(3, 'Derek Ivanich', 'calle 4 # 5-45 ', 'A', 4),
	(4, 'Don Barberias', 'cr5 #2-75 ', 'A', 5),
	(5, 'Barber Sergi', 'calle1 # 5a 75', 'A', 6),
	(6, 'barberia leandro', 'callle 7 #e 35', 'I', 7),
	(7, 'P. J Barbershop', 'calle 17 # 5e 377', 'A', 3),
	(8, 'style people', 'cr 1 # 5b-28', 'A', 8),
	(12, 'paris babershop', 'cr5 #2-75 ', 'A', 6);
/*!40000 ALTER TABLE `barberia` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.barberia_galeria
CREATE TABLE IF NOT EXISTS `barberia_galeria` (
  `idBarberia_Galeria` int(11) NOT NULL AUTO_INCREMENT,
  `fk_idbarberia` int(200) NOT NULL,
  `fk_idGaleria` int(200) NOT NULL,
  PRIMARY KEY (`idBarberia_Galeria`),
  KEY `fk_Barberia_Galeria_barberia1_idx` (`fk_idbarberia`),
  KEY `fk_Barberia_Galeria_Galeria1_idx` (`fk_idGaleria`),
  CONSTRAINT `fk_Barberia_Galeria_barberia1` FOREIGN KEY (`fk_idbarberia`) REFERENCES `barberia` (`idbarberia`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Barberia_Galeria_Galeria1` FOREIGN KEY (`fk_idGaleria`) REFERENCES `galeria` (`idGaleria`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.barberia_galeria: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `barberia_galeria` DISABLE KEYS */;
INSERT INTO `barberia_galeria` (`idBarberia_Galeria`, `fk_idbarberia`, `fk_idGaleria`) VALUES
	(1, 2, 2),
	(2, 3, 3),
	(3, 4, 4),
	(4, 5, 5),
	(5, 6, 6),
	(6, 7, 7),
	(7, 8, 8),
	(8, 12, 9);
/*!40000 ALTER TABLE `barberia_galeria` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.barbero
CREATE TABLE IF NOT EXISTS `barbero` (
  `idBarbero` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_idUsuario` int(100) NOT NULL,
  `barberia_idbarberia` int(11) NOT NULL,
  PRIMARY KEY (`idBarbero`),
  KEY `fk_Barbero_usuario1_idx` (`usuario_idUsuario`),
  KEY `fk_Barbero_barberia1_idx` (`barberia_idbarberia`),
  CONSTRAINT `fk_Barbero_barberia1` FOREIGN KEY (`barberia_idbarberia`) REFERENCES `barberia` (`idbarberia`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Barbero_usuario1` FOREIGN KEY (`usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.barbero: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `barbero` DISABLE KEYS */;
INSERT INTO `barbero` (`idBarbero`, `usuario_idUsuario`, `barberia_idbarberia`) VALUES
	(1, 22, 3),
	(2, 23, 2),
	(3, 24, 3),
	(4, 28, 5),
	(5, 30, 5),
	(6, 31, 5),
	(7, 32, 5),
	(8, 34, 7),
	(9, 36, 8);
/*!40000 ALTER TABLE `barbero` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.cita
CREATE TABLE IF NOT EXISTS `cita` (
  `idcita` int(11) NOT NULL AUTO_INCREMENT,
  `Barbero_idBarbero` int(11) NOT NULL,
  `Cliente_idCliente` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `Horario_idHorario` int(11) NOT NULL,
  `motivo_idmotivo` int(11) NOT NULL,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idcita`),
  KEY `fk_cita_motivo1_idx` (`motivo_idmotivo`),
  KEY `fk_cita_Horario1_idx` (`Horario_idHorario`),
  KEY `fk_cita_Barbero1_idx` (`Barbero_idBarbero`),
  KEY `fk_cita_Cliente1_idx` (`Cliente_idCliente`),
  CONSTRAINT `fk_cita_Barbero1` FOREIGN KEY (`Barbero_idBarbero`) REFERENCES `barbero` (`idBarbero`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_cita_Cliente1` FOREIGN KEY (`Cliente_idCliente`) REFERENCES `cliente` (`idCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_cita_Horario1` FOREIGN KEY (`Horario_idHorario`) REFERENCES `horario` (`idHorario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_cita_motivo1` FOREIGN KEY (`motivo_idmotivo`) REFERENCES `motivo` (`idmotivo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.cita: ~14 rows (aproximadamente)
/*!40000 ALTER TABLE `cita` DISABLE KEYS */;
INSERT INTO `cita` (`idcita`, `Barbero_idBarbero`, `Cliente_idCliente`, `fecha`, `Horario_idHorario`, `motivo_idmotivo`, `estado`) VALUES
	(5, 3, 1, '2019-02-05', 4, 2, 'I'),
	(6, 2, 3, '2019-02-20', 13, 1, 'I'),
	(7, 2, 1, '2019-02-06', 1, 3, 'I'),
	(8, 1, 4, '2019-02-11', 2, 3, 'I'),
	(9, 2, 3, '2019-02-06', 5, 1, 'I'),
	(10, 8, 1, '2019-02-19', 4, 1, 'I'),
	(11, 1, 1, '2019-02-20', 10, 1, 'I'),
	(12, 4, 1, '2019-02-21', 13, 1, 'I'),
	(13, 2, 1, '2019-02-18', 10, 1, 'I'),
	(14, 2, 1, '2019-03-01', 1, 1, 'I'),
	(15, 2, 4, '2019-02-01', 1, 1, 'I'),
	(16, 3, 4, '2019-03-01', 1, 1, 'I'),
	(17, 2, 5, '2019-03-07', 1, 1, 'I'),
	(18, 2, 3, '2019-03-07', 2, 1, 'I');
/*!40000 ALTER TABLE `cita` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_idUsuario` int(100) NOT NULL,
  PRIMARY KEY (`idCliente`),
  KEY `fk_Cliente_usuario1_idx` (`usuario_idUsuario`),
  CONSTRAINT `fk_Cliente_usuario1` FOREIGN KEY (`usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.cliente: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`idCliente`, `usuario_idUsuario`) VALUES
	(3, 14),
	(4, 16),
	(1, 17),
	(2, 21),
	(5, 25),
	(6, 26);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.empresa
CREATE TABLE IF NOT EXISTS `empresa` (
  `idempresa` int(11) NOT NULL,
  `Nombre_empresa` varchar(45) DEFAULT NULL,
  `Nit` int(11) DEFAULT NULL,
  `celular` bigint(20) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idempresa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.empresa: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` (`idempresa`, `Nombre_empresa`, `Nit`, `celular`, `correo`) VALUES
	(1, 'The_Barbershop´s', 1232323, 3165807846, 'thebarbershop@hotmail.com');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.galeria
CREATE TABLE IF NOT EXISTS `galeria` (
  `idGaleria` int(11) NOT NULL AUTO_INCREMENT,
  `Foto` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idGaleria`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.galeria: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `galeria` DISABLE KEYS */;
INSERT INTO `galeria` (`idGaleria`, `Foto`) VALUES
	(2, '../../imagenes/otro.jpg'),
	(3, '../../imagenes/dereck.jpg'),
	(4, '../../imagenes/Donbarberias.jpg'),
	(5, '../../imagenes/otra.jpg'),
	(6, '../../imagenes/casa.png'),
	(7, '../../imagenes/fachada-pj-barber-shop.jpg'),
	(8, '../../imagenes/style.jpg'),
	(9, '../../imagenes/paris.jpg');
/*!40000 ALTER TABLE `galeria` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.horario
CREATE TABLE IF NOT EXISTS `horario` (
  `idHorario` int(11) NOT NULL,
  `hora` time DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idHorario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.horario: ~17 rows (aproximadamente)
/*!40000 ALTER TABLE `horario` DISABLE KEYS */;
INSERT INTO `horario` (`idHorario`, `hora`, `estado`) VALUES
	(1, '08:00:00', 'A'),
	(2, '08:30:00', 'A'),
	(3, '09:00:00', 'A'),
	(4, '09:30:00', 'A'),
	(5, '10:00:00', 'A'),
	(6, '10:30:00', 'A'),
	(7, '11:00:00', 'A'),
	(8, '11:30:00', 'A'),
	(9, '12:00:00', 'A'),
	(10, '14:00:00', 'A'),
	(11, '14:30:00', 'A'),
	(12, '15:00:00', 'A'),
	(13, '15:30:00', 'A'),
	(14, '16:00:00', 'A'),
	(15, '16:30:00', 'A'),
	(16, '17:00:00', 'A'),
	(17, '17:30:00', 'A');
/*!40000 ALTER TABLE `horario` ENABLE KEYS */;

-- Volcando estructura para procedimiento babershop.insert_barberia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_barberia`(
	
	IN `p_nombre_barberia` VARCHAR(50),
	IN `p_direccion` VARCHAR(50),
	IN `p_propietario` VARCHAR(50),
	IN `p_imagen` VARCHAR(50)  
)
BEGIN

insert into barberia(nombre,direccion,estado,fk_idPropietario)values(p_nombre_barberia,p_direccion,'A',p_propietario);
insert into galeria(Foto)values(p_imagen);
insert into barberia_galeria(fk_idbarberia,fk_idGaleria)values((select max(idbarberia)from barberia),(select max(idGaleria)from galeria));
END//
DELIMITER ;

-- Volcando estructura para procedimiento babershop.insert_barbero
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_barbero`(
	IN `p_nombre` VARCHAR(50),
	IN `p_apellidos` VARCHAR(50),
	IN `p_correo` VARCHAR(50),
	IN `p_contrasena` VARCHAR(50),
	IN `p_recontrasena` VARCHAR(50),
	IN `Id_barberia` INT (50)
  
)
BEGIN
DECLARE cont int;
set cont=(select max(idUsuario)+1 from Usuario);
insert into Usuario values(cont,p_nombre,p_apellidos,p_correo,md5(p_contrasena),md5(p_recontrasena),'A');
insert into usuario_rol (Usuario_idUsuario,rol_idrol) values((select max(idusuario)from Usuario),2);
insert into barbero (usuario_idUsuario,barberia_idbarberia)values ((select max(idusuario)from Usuario),Id_barberia);
END//
DELIMITER ;

-- Volcando estructura para procedimiento babershop.insert_cita
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_cita`(
	IN `p_barbero` INT(11),
    IN `P_cliente` int(11),
	IN `p_fecha` date,
	IN `p_hora`INT(200),
    IN `p_motivo` INT(200)

  
)
BEGIN

DECLARE cont int;
set cont=(select max(idcita)+1 from cita);
insert into cita values(cont,p_barbero,P_cliente,p_fecha,
p_hora,p_motivo,'I');

END//
DELIMITER ;

-- Volcando estructura para procedimiento babershop.insert_Propietario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_Propietario`(
	IN `p_nombre` VARCHAR(50),
	IN `p_apellidos` VARCHAR(50),
	IN `p_correo` VARCHAR(50),
	IN `p_contrasena` VARCHAR(50),
	IN `p_recontrasena` VARCHAR(50)	
	
)
BEGIN
DECLARE cont int;
set cont=(select max(idUsuario)+1 from Usuario);
insert into Usuario values(cont,p_nombre,p_apellidos,p_correo,md5(p_contrasena),md5(p_recontrasena),'A');
insert into usuario_rol (Usuario_idUsuario,rol_idrol) values((select max(idusuario)from Usuario),4);
insert into propietario (usuario_idUsuario)values ((select max(idusuario)from Usuario));
END//
DELIMITER ;

-- Volcando estructura para procedimiento babershop.insert_usuario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_usuario`(
	IN `p_nombre` VARCHAR(50),
	IN `p_apellidos` VARCHAR(50),
	IN `p_correo` VARCHAR(50),
	IN `p_contrasena` VARCHAR(50),
	IN `p_recontrasena` VARCHAR(50)
  
)
BEGIN
DECLARE cont int;
set cont=(select max(idUsuario)+1 from Usuario);
insert into Usuario values(cont,p_nombre,p_apellidos,p_correo,md5(p_contrasena),md5(p_recontrasena),'A');
insert into usuario_rol (Usuario_idUsuario,rol_idrol) values((select max(idusuario)from Usuario),3);
insert into cliente (usuario_idUsuario)values ((select max(idusuario)from Usuario));
END//
DELIMITER ;

-- Volcando estructura para tabla babershop.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `idmenu` int(11) NOT NULL,
  `titulo` varchar(45) DEFAULT NULL,
  `icono` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmenu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.menu: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` (`idmenu`, `titulo`, `icono`) VALUES
	(1, 'Gestionar Usuario', 'fa fa-user'),
	(2, 'Gestionar Barberias', 'fa fa-home'),
	(3, 'Gestionar Barbero', 'fa fa-user'),
	(4, 'Citas', 'fa fa-language'),
	(5, 'Reportes', 'fa fa-user');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.motivo
CREATE TABLE IF NOT EXISTS `motivo` (
  `idmotivo` int(11) NOT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idmotivo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.motivo: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `motivo` DISABLE KEYS */;
INSERT INTO `motivo` (`idmotivo`, `descripcion`) VALUES
	(1, 'Corte de Cabello'),
	(2, 'Tinte'),
	(3, 'Tratamiento de Barba'),
	(4, 'Corte Barba ');
/*!40000 ALTER TABLE `motivo` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.propietario
CREATE TABLE IF NOT EXISTS `propietario` (
  `idPropietario` int(11) NOT NULL AUTO_INCREMENT,
  `usuario_idUsuario` int(100) NOT NULL,
  PRIMARY KEY (`idPropietario`),
  KEY `fk_Propietario_usuario1_idx` (`usuario_idUsuario`),
  CONSTRAINT `fk_Propietario_usuario1` FOREIGN KEY (`usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.propietario: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `propietario` DISABLE KEYS */;
INSERT INTO `propietario` (`idPropietario`, `usuario_idUsuario`) VALUES
	(3, 18),
	(4, 19),
	(5, 20),
	(6, 27),
	(7, 29),
	(8, 33),
	(9, 35),
	(10, 37);
/*!40000 ALTER TABLE `propietario` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `idrol` int(11) NOT NULL,
  `Nombre` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idrol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.rol: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` (`idrol`, `Nombre`, `estado`) VALUES
	(1, 'Administrador', 'Activo'),
	(2, 'Barbero', 'Activo'),
	(3, 'Cliente', 'Activo'),
	(4, 'Propietario', 'Activo');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.rol_vista
CREATE TABLE IF NOT EXISTS `rol_vista` (
  `idrol_vista` int(11) NOT NULL,
  `rol_idrol` int(11) NOT NULL,
  `vista_idvista` int(11) NOT NULL,
  PRIMARY KEY (`idrol_vista`),
  KEY `fk_rol_vista_rol1_idx` (`rol_idrol`),
  KEY `fk_rol_vista_vista1_idx` (`vista_idvista`),
  CONSTRAINT `fk_rol_vista_rol1` FOREIGN KEY (`rol_idrol`) REFERENCES `rol` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rol_vista_vista1` FOREIGN KEY (`vista_idvista`) REFERENCES `vista` (`idvista`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.rol_vista: ~19 rows (aproximadamente)
/*!40000 ALTER TABLE `rol_vista` DISABLE KEYS */;
INSERT INTO `rol_vista` (`idrol_vista`, `rol_idrol`, `vista_idvista`) VALUES
	(1, 1, 1),
	(2, 1, 2),
	(3, 3, 3),
	(4, 1, 4),
	(5, 1, 10),
	(6, 1, 6),
	(7, 1, 7),
	(8, 2, 18),
	(9, 4, 8),
	(10, 4, 5),
	(11, 4, 9),
	(12, 1, 11),
	(13, 3, 12),
	(14, 4, 13),
	(15, 4, 14),
	(16, 3, 15),
	(17, 1, 16),
	(18, 1, 17),
	(19, 2, 19);
/*!40000 ALTER TABLE `rol_vista` ENABLE KEYS */;

-- Volcando estructura para procedimiento babershop.update_barbero
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_barbero`(
p_nombre varchar(100),
p_apellido varchar (100),
p_correo varchar (100),
p_contrasena varchar (100),
p_idusuario int  (11),
p_estado varchar(100),
p_idBarberia int (11)
)
BEGIN

UPDATE usuario SET nombres=p_nombre , apellidos =p_apellido , correo =p_correo , contrasena=md5(p_contrasena),estado=p_estado WHERE idUsuario=p_idusuario; 
UPDATE barbero SET barberia_idbarberia=p_idBarberia WHERE barbero.usuario_idUsuario=p_idusuario ;

END//
DELIMITER ;

-- Volcando estructura para procedimiento babershop.update_cita
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_cita`(
	IN `p_barbero` INT(11),
    IN `P_cliente` int(11),
	IN `p_fecha` date,
	IN `p_hora`INT(200),
    IN `p_motivo` INT(200),
	IN `p_idcita` INT (200)  
)
BEGIN

DECLARE cont int;
UPDATE `babershop`.`cita` SET Barbero_idBarbero=p_barbero,Cliente_idCliente=P_cliente, 
fecha=p_fecha, Horario_idHorario=p_hora,motivo_idmotivo=p_motivo WHERE `idcita`=p_idcita;

END//
DELIMITER ;

-- Volcando estructura para procedimiento babershop.update_uauario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `update_uauario`(
p_nombre varchar(100),
p_apellido varchar (100),
p_correo varchar (100),
p_contrasena varchar (100),
p_idusuario int  (11),
p_idrol int (11)
)
BEGIN

UPDATE usuario SET nombres=p_nombre , apellidos =p_apellido , correo =p_correo , contrasena=md5(p_contrasena)WHERE idUsuario=p_idusuario; 
UPDATE usuario_rol set rol_idrol=p_idrol  WHERE Usuario_idUsuario=p_idusuario ;

END//
DELIMITER ;

-- Volcando estructura para tabla babershop.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `idUsuario` int(100) NOT NULL AUTO_INCREMENT,
  `nombres` varchar(45) DEFAULT NULL,
  `apellidos` varchar(45) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  `contrasena` varchar(45) DEFAULT NULL,
  `recontrasena` varchar(45) DEFAULT NULL,
  `estado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.usuario: ~24 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`idUsuario`, `nombres`, `apellidos`, `correo`, `contrasena`, `recontrasena`, `estado`) VALUES
	(14, 'Juan', 'Florez', 'cami@hotmail.com', '202cb962ac59075b964b07152d234b70', '202cb962ac59075b964b07152d234b70', 'A'),
	(15, 'Jaime Andres', 'Florez', 'jaflors2010@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(16, 'David Hernando ', 'Florez', 'moncho@gmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(17, 'Camilo ', 'Ruiz Tamayo', 'ruisa@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(18, 'Victor', 'torres', 'victorres@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(19, 'Ruben  ', 'Fernandes', 'rubencho@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(20, 'Jader', 'Orozco', 'jader@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(21, 'Camilo', 'Rodriguez', 'rodri@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(22, 'Carlos', 'Astudillos', 'caliche@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(23, 'Carlos Javier', 'Ramirez', 'javi@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(24, 'Juan Camilo', 'Ramirez Rodríguez', 'juan@outlook.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(25, 'Yeison', 'Martines', 'yeison@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(26, 'fabian', ' cuellar', 'cuellar@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(27, 'sergio ', 'Marin', 'sergi@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(28, 'Edwar  ', 'Bernal', 'edwar@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(29, 'leandro', 'nieto', 'leandro@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(30, 'Alan', 'Brito', 'alan@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'I'),
	(31, 'Fernando ', 'Arias', 'fer@outlook.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'I'),
	(32, 'julian', 'cuellar', 'juliano@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'I'),
	(33, 'Gustavo', 'Vega', 'gustavo@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(34, 'Bob', 'Jungles', 'bob@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(35, 'Nicolas', 'Mendoza', 'nico@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A'),
	(36, 'Jhon ', 'Ospitia', 'Jhon@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'I'),
	(37, 'Javier', 'Rodriges', 'jac@hotmail.com', '81dc9bdb52d04dc20036dbd8313ed055', '81dc9bdb52d04dc20036dbd8313ed055', 'A');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.usuario_rol
CREATE TABLE IF NOT EXISTS `usuario_rol` (
  `idusuario_rol` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario_idUsuario` int(11) NOT NULL,
  `rol_idrol` int(11) NOT NULL,
  PRIMARY KEY (`idusuario_rol`),
  KEY `fk_usuario_rol_Usuario1_idx` (`Usuario_idUsuario`),
  KEY `fk_usuario_rol_rol1_idx` (`rol_idrol`),
  CONSTRAINT `fk_usuario_rol_rol1` FOREIGN KEY (`rol_idrol`) REFERENCES `rol` (`idrol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuario_rol_Usuario1` FOREIGN KEY (`Usuario_idUsuario`) REFERENCES `usuario` (`idUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.usuario_rol: ~24 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario_rol` DISABLE KEYS */;
INSERT INTO `usuario_rol` (`idusuario_rol`, `Usuario_idUsuario`, `rol_idrol`) VALUES
	(1, 14, 3),
	(2, 15, 1),
	(3, 16, 3),
	(4, 17, 3),
	(7, 18, 4),
	(8, 19, 4),
	(9, 20, 4),
	(10, 21, 3),
	(11, 22, 2),
	(12, 23, 2),
	(13, 24, 2),
	(14, 25, 3),
	(15, 26, 3),
	(16, 27, 4),
	(17, 28, 2),
	(18, 29, 4),
	(19, 30, 2),
	(20, 31, 2),
	(21, 32, 2),
	(22, 33, 4),
	(23, 34, 2),
	(24, 35, 4),
	(25, 36, 2),
	(26, 37, 4);
/*!40000 ALTER TABLE `usuario_rol` ENABLE KEYS */;

-- Volcando estructura para tabla babershop.vista
CREATE TABLE IF NOT EXISTS `vista` (
  `idvista` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `url` varchar(200) DEFAULT NULL,
  `icono` varchar(45) DEFAULT NULL,
  `menu_idmenu` int(11) NOT NULL,
  PRIMARY KEY (`idvista`),
  KEY `fk_vista_menu1_idx` (`menu_idmenu`),
  CONSTRAINT `fk_vista_menu1` FOREIGN KEY (`menu_idmenu`) REFERENCES `menu` (`idmenu`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla babershop.vista: ~19 rows (aproximadamente)
/*!40000 ALTER TABLE `vista` DISABLE KEYS */;
INSERT INTO `vista` (`idvista`, `nombre`, `url`, `icono`, `menu_idmenu`) VALUES
	(1, 'Usuarios Registrados', '../Administrador\\Registrar_usu_admi.aspx', 'fa fa-meh-o', 1),
	(2, 'Registrar barberia ', '../Administrador\\Registrar_barberia.aspx', 'fa fa-hand-paper-o', 2),
	(3, 'Actualizar Usuario', '../Invitado\\Asignar_Cita.aspx', 'fa fa-calendar-check-o', 1),
	(4, 'Consultar Barberias', '../Administrador\\Consultar_barberia.aspx', 'fa fa-search', 2),
	(5, 'Registrar Mis Barberos', '../Propietario/Registrar_Barbero.aspx', 'fa fa-meh-o', 3),
	(6, 'Registrar Cita', '../Administrador/Registrar _Cita.aspx', 'fa fa-calendar-check-o', 4),
	(7, 'Consultar Citas', '../Administrador/Consultar_Cita.aspx', 'fa fa-calendar-check-o', 4),
	(8, 'Mis  Barberias ', '../Propietario/Mis_barberias.aspx', 'fa fa-meh-o', 2),
	(9, 'Consultar barberos ', '../Propietario/Consultar_Barberos_pr.aspx', 'fa fa-meh-o', 3),
	(10, 'Barberos Registrados ', '../Administrador/Barberos_Registrados.aspx', 'fa fa-meh-o', 3),
	(11, 'Activar Barberias ', '../Administrador/Actualizar_barberia.aspx', 'fa fa-hand-paper-o', 2),
	(12, 'Barberias Registradas', '../Cliente/consul_barberias_cliente.aspx', 'fa fa fa-binoculars', 4),
	(13, 'Registrar Barberias', '../Propietario/Registrar_Barberia _Propietario.aspx', 'fa fa-hand-paper-o', 2),
	(14, 'Eliminar Barberias', '../Propietario/Eliminar_Barberia.aspx', 'fa fa-meh-o', 2),
	(15, 'Consultar Citas', '../Cliente/Consultar_Cita_cliente.aspx', 'fa fa fa-binoculars', 4),
	(16, 'Citas Registradas', '../Administrador/Consulta_detalle_citas.aspx', 'fa fa-hand-paper-o', 5),
	(17, 'Propietarios Registrados', '../Administrador/Consultar_propietarios.aspx', 'fa fa-meh-o', 5),
	(18, 'Consultar mis Citas', '../Barbero/consulta_mis citas.aspx', 'fa fa-meh-o', 4),
	(19, 'Registrar mis Citas', '../Barbero/Registrar_cita.aspx', 'fa fa-hand-paper-o', 4);
/*!40000 ALTER TABLE `vista` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
