USE [master]
GO
CREATE DATABASE [StudentDataBase] ON PRIMARY
(NAME = 'StudentDataBase',
FILENAME = '{app}\StudentDataBase.mdf',
SIZE = 100MB, MAXSIZE = 10GB, FILEGROWTH = 10%)
LOG ON (NAME = 'StudentDataBase_Log',
FILENAME = '{app}\StudentDataBase_Log.ldf',
SIZE = 50MB, MAXSIZE = 2GB, FILEGROWTH = 10%)
GO