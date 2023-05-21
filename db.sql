-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 16 2023 г., 04:04
-- Версия сервера: 5.5.62
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `учёт по и лицензий`
--

-- --------------------------------------------------------

--
-- Структура таблицы `историяиспользования`
--

CREATE TABLE `историяиспользования` (
  `Id` int(11) NOT NULL,
  `id_по` int(11) NOT NULL,
  `id_компьютера` int(11) NOT NULL,
  `дата_использования` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `историяиспользования`
--

INSERT INTO `историяиспользования` (`Id`, `id_по`, `id_компьютера`, `дата_использования`) VALUES
(1, 1, 1, '15.03.2023'),
(2, 2, 2, '15.02.2023'),
(3, 3, 3, '15.02.2023');

-- --------------------------------------------------------

--
-- Структура таблицы `компьютеры`
--

CREATE TABLE `компьютеры` (
  `Id` int(11) NOT NULL,
  `название` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ip_адресс` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
  `Описание` varchar(255) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `компьютеры`
--

INSERT INTO `компьютеры` (`Id`, `название`, `ip_адресс`, `Описание`) VALUES
(1, 'Компьютер сотрудника', '192.158.1.38.', 'Рабочий компьютер сотрудника отдела бухгалтерии'),
(2, 'Компьютер сотрудника', '192.162.1.42.', 'Рабочий компьютер сотрудника отдела бухгалтерии'),
(3, 'Компьютер сотрудника', '192.163.1.39.', 'Рабочий компьютер сотрудника отдела бухгалтерии');

-- --------------------------------------------------------

--
-- Структура таблицы `по`
--

CREATE TABLE `по` (
  `id` int(10) NOT NULL,
  `название` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `версия` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `описание` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `категория` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `дата_установки` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
  `дата_окончания_лицензии` varchar(10) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `по`
--

INSERT INTO `по` (`id`, `название`, `версия`, `описание`, `категория`, `дата_установки`, `дата_окончания_лицензии`) VALUES
(1, '1С:Бухгалтерия 8', 'ПРОФ', 'профессиональный инструмент бухгалтера, с помощью ...', 'Специализированная', '12.07.2019', '12.07.2023'),
(2, '1С:Документооборот 8', 'ПРОФ', 'Современная ECM-система (Enterprise Content Manage...', 'Специализированная', '12.07.2019', '12.07.2023'),
(3, '1С:Зарплата и управление персоналом 8\r\n', 'ПРОФ', 'Программа массового назначения, позволяющая в комп...', 'Специализированная', '12.07.2019', '12.07.2023');

-- --------------------------------------------------------

--
-- Структура таблицы `пользователи`
--

CREATE TABLE `пользователи` (
  `Id` int(11) NOT NULL,
  `login` varchar(32) NOT NULL,
  `pass` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `пользователи`
--

INSERT INTO `пользователи` (`Id`, `login`, `pass`) VALUES
(1, 'окунец', '12345');

-- --------------------------------------------------------

--
-- Структура таблицы `лицензии`
--

CREATE TABLE `лицензии` (
  `id` int(11) NOT NULL,
  `название` varchar(255) NOT NULL,
  `тип` varchar(255) NOT NULL,
  `дата_начала_действия` varchar(10) NOT NULL,
  `дата_окончания_действия` varchar(10) NOT NULL,
  `количество_устройств` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `лицензии`
--

INSERT INTO `лицензии` (`id`, `название`, `тип`, `дата_начала_действия`, `дата_окончания_действия`, `количество_устройств`) VALUES
(1, '1С:Бухгалтерия 8', 'Многопользовательская', '12.07.2019', '12.07.2023', 4),
(2, '1С:Документооборот 8', 'Многопользовательская', '12.07.2019', '12.07.2023', 4),
(3, '1С:Зарплата и управление персоналом 8', 'Многопользовательская', '12.07.2019', '12.07.2023', 4);

-- --------------------------------------------------------

--
-- Структура таблицы `установки`
--

CREATE TABLE `установки` (
  `Id` int(11) NOT NULL,
  `id_по` int(11) NOT NULL,
  `id_компьютера` int(11) NOT NULL,
  `дата_установки` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `установки`
--

INSERT INTO `установки` (`Id`, `id_по`, `id_компьютера`, `дата_установки`) VALUES
(1, 1, 1, '12.07.2019'),
(2, 2, 2, '12.07.2019'),
(3, 3, 3, '12.07.2019');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `историяиспользования`
--
ALTER TABLE `историяиспользования`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_по` (`id_по`,`id_компьютера`),
  ADD KEY `id_компьютера` (`id_компьютера`);

--
-- Индексы таблицы `компьютеры`
--
ALTER TABLE `компьютеры`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `по`
--
ALTER TABLE `по`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `пользователи`
--
ALTER TABLE `пользователи`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `лицензии`
--
ALTER TABLE `лицензии`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `установки`
--
ALTER TABLE `установки`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `id_по` (`id_по`),
  ADD UNIQUE KEY `id_компьютера` (`id_компьютера`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `историяиспользования`
--
ALTER TABLE `историяиспользования`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `компьютеры`
--
ALTER TABLE `компьютеры`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `по`
--
ALTER TABLE `по`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `пользователи`
--
ALTER TABLE `пользователи`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `лицензии`
--
ALTER TABLE `лицензии`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `установки`
--
ALTER TABLE `установки`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
