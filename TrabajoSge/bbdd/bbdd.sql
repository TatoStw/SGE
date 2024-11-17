CREATE DATABASE `bd_p1agiles` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `bd_p1agiles`;

CREATE TABLE `autores` (
  `id_autor` int(11) NOT NULL,
  `nombre_autor` varchar(45) NOT NULL,
  `correo_autor` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_autor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `bibliotecas` (
  `cod_biblioteca` int(11) NOT NULL,
  `provincia_biblioteca` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_biblioteca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `libros` (
  `isbn_libro` varchar(12) NOT NULL,
  `nombre_libro` varchar(45) NOT NULL,
  `editorial_libro` varchar(45) NOT NULL,
  `anio_libro` int(4) NOT NULL,
  `genero` varchar(45) NOT NULL,
  `precio_libro` decimal(2,0) NOT NULL,
  `cantidad_libro` int(11) NOT NULL,
  `cod_biblioteca` int(11) NOT NULL,
  `autor_libro` int(11) NOT NULL,
  PRIMARY KEY (`isbn_libro`),
  KEY `autor_libro` (`autor_libro`),
  KEY `cod_biblioteca` (`cod_biblioteca`),
  CONSTRAINT `libros_ibfk_1` FOREIGN KEY (`autor_libro`) REFERENCES `autores` (`id_autor`),
  CONSTRAINT `libros_ibfk_2` FOREIGN KEY (`cod_biblioteca`) REFERENCES `bibliotecas` (`cod_biblioteca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `recibos` (
  `id_recibo` int(11) NOT NULL,
  `num_socio` int(11) NOT NULL,
  `fecha_recibo` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `reciboscol` tinyint(4) NOT NULL,
  `isbn_libro` varchar(45) NOT NULL,
  PRIMARY KEY (`id_recibo`),
  KEY `recibos_ibfk_1` (`num_socio`),
  KEY `isbn_libro` (`isbn_libro`),
  CONSTRAINT `recibos_ibfk_1` FOREIGN KEY (`num_socio`) REFERENCES `socios` (`num_socio`),
  CONSTRAINT `recibos_ibfk_2` FOREIGN KEY (`isbn_libro`) REFERENCES `libros` (`isbn_libro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `sanciones` (
  `id_sancion` int(11) NOT NULL,
  `num_socio` int(11) NOT NULL,
  `coste_sancion` decimal(2,0) NOT NULL COMMENT 'sanción de retraso o no entrega -> 3€\nsanción de deterioro -> leve: 3€, grave: coste libro',
  `fecha_sancion` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `tipo_sancion` varchar(45) NOT NULL,
  `gravedad_deterioro_sancion` tinyint(4) DEFAULT NULL,
  `isbn_libro` varchar(45) NOT NULL,
  PRIMARY KEY (`id_sancion`),
  KEY `num_socio` (`num_socio`),
  KEY `isbn_libro` (`isbn_libro`),
  CONSTRAINT `sanciones_ibfk_1` FOREIGN KEY (`num_socio`) REFERENCES `socios` (`num_socio`),
  CONSTRAINT `sanciones_ibfk_2` FOREIGN KEY (`isbn_libro`) REFERENCES `libros` (`isbn_libro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `socios` (
  `num_socio` int(11) NOT NULL,
  `dni_socio` varchar(9) NOT NULL,
  `nombre_socio` varchar(45) NOT NULL,
  `cnta_bancaria_socio` varchar(45) NOT NULL,
  `lugar_socio` varchar(45) NOT NULL,
  `fecha_alta_socio` timestamp NOT NULL DEFAULT current_timestamp(),
  `cuota_pagada_socio` tinyint(4) NOT NULL,
  `telefono_socio` int(9) NOT NULL,
  PRIMARY KEY (`num_socio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `nombre_usuario` varchar(45) NOT NULL,
  `correo_usuario` varchar(45) NOT NULL,
  PRIMARY KEY (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
