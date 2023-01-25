-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 2023-01-25 13:37:36
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
-- テーブルの構造 `bestposition_table`
--

CREATE TABLE `bestposition_table` (
  `id` int(11) NOT NULL,
  `xb` text NOT NULL,
  `yb` text NOT NULL,
  `zb` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- テーブルの構造 `position_table`
--

CREATE TABLE `position_table` (
  `id` int(11) NOT NULL,
  `x` text NOT NULL,
  `y` text NOT NULL,
  `z` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(7, '', 21.2, '2022-12-15 16:17:09'),
(8, '', 21.2, '2022-12-15 16:17:14'),
(9, '', 21.1, '2022-12-16 16:00:37'),
(10, 'AAAA', 21.3, '2022-12-16 16:04:44'),
(11, 'AAAAA', 21, '2022-12-23 15:11:17'),
(12, 'ZZ', 21.4, '2022-12-23 15:11:41'),
(13, 'A', 21.7, '2023-01-20 16:43:19'),
(14, 'AA', 21.2, '2023-01-24 14:11:57'),
(15, 'AA', 21.1, '2023-01-24 14:12:39'),
(16, 'AAA', 21.5, '2023-01-24 14:37:29');

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
  MODIFY `time_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
