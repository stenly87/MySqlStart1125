--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 12.03.2025 13:12:48
-- Версия сервера: 10.3.39
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE `1125_new_2025`;

--
-- Удалить таблицу `Clients`
--
DROP TABLE IF EXISTS Clients;

--
-- Установка базы данных по умолчанию
--
USE `1125_new_2025`;

--
-- Создать таблицу `Clients`
--
CREATE TABLE Clients (
  id int(11) NOT NULL AUTO_INCREMENT,
  Fname varchar(255) DEFAULT NULL,
  Lname varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

-- 
-- Вывод данных для таблицы Clients
--
INSERT INTO Clients VALUES
(1, 'Иван', 'Петров'),
(2, 'Петр', 'Иванов'),
(3, 'asd', 'asdas'),
(4, 'Петр', 'Иванов'),
(5, 'Петр', 'Иванов');

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;