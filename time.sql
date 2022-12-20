-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 2022-12-20 13:56:44
-- サーバのバージョン： 10.4.24-MariaDB
-- PHP のバージョン: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `time`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `time_table`
--

CREATE TABLE `time_table` (
  `time_id` int(11) NOT NULL,
  `name` text NOT NULL,
  `time` float NOT NULL,
  `time_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- テーブルのデータのダンプ `time_table`
--

INSERT INTO `time_table` (`time_id`, `name`, `time`, `time_date`) VALUES
(1, 'a', 1, '0000-00-00 00:00:00'),
(2, 'b', 5, '0000-00-00 00:00:00'),
(3, 'c', 8, '2022-11-08 19:59:17'),
(4, 'あいう', 15, '2022-11-17 13:11:19'),
(5, '', 0, '2022-12-15 15:12:29'),
(6, '', 0, '2022-12-15 15:15:21'),
(7, '', 21.2, '2022-12-15 16:17:09'),
(8, '', 21.2, '2022-12-15 16:17:14'),
(9, '', 21.1, '2022-12-16 16:00:37'),
(10, 'AAAA', 21.3, '2022-12-16 16:04:44');

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `time_table`
--
ALTER TABLE `time_table`
  ADD PRIMARY KEY (`time_id`);

--
-- ダンプしたテーブルの AUTO_INCREMENT
--

--
-- テーブルの AUTO_INCREMENT `time_table`
--
ALTER TABLE `time_table`
  MODIFY `time_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
