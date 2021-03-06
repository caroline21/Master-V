USE [master]
GO
/****** Object:  Database [dbMaster-V]    Script Date: 31/08/2015 12:01:45 a.m. ******/
CREATE DATABASE [dbMaster-V]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbMaster-V', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\dbMaster-V.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbMaster-V_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\dbMaster-V_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbMaster-V] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbMaster-V].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbMaster-V] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbMaster-V] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbMaster-V] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbMaster-V] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbMaster-V] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbMaster-V] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbMaster-V] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dbMaster-V] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbMaster-V] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbMaster-V] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbMaster-V] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbMaster-V] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbMaster-V] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbMaster-V] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbMaster-V] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbMaster-V] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbMaster-V] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbMaster-V] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbMaster-V] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbMaster-V] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbMaster-V] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbMaster-V] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbMaster-V] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbMaster-V] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbMaster-V] SET  MULTI_USER 
GO
ALTER DATABASE [dbMaster-V] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbMaster-V] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbMaster-V] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbMaster-V] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [dbMaster-V]
GO
/****** Object:  Table [dbo].[tblAlimentos]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAlimentos](
	[IdSolicitud] [int] NOT NULL,
	[cantidad] [float] NOT NULL,
	[concepto] [varchar](100) NOT NULL,
	[total] [float] NOT NULL,
	[numComida] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblComprobacion]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblComprobacion](
	[Idcomprobacion] [int] IDENTITY(1,1) NOT NULL,
	[IdSolicitud] [int] NOT NULL,
	[IdProyecto] [varchar](50) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[gerenteAdmin] [varchar](100) NULL,
	[jefeInmediato] [varchar](100) NULL,
	[areaContable] [varchar](100) NULL,
 CONSTRAINT [PK_tblComprobación] PRIMARY KEY CLUSTERED 
(
	[Idcomprobacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblComprobacionGastos]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblComprobacionGastos](
	[IdComprobacion] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tarifa] [float] NULL,
	[hospedaje] [float] NULL,
	[alimentacion] [float] NULL,
	[gasolina] [float] NULL,
	[taxi] [float] NULL,
	[caseta] [float] NULL,
	[tel] [float] NULL,
	[estacionamiento] [float] NULL,
	[internet] [float] NULL,
	[paquetEnvio] [float] NULL,
	[comidaNeg] [float] NULL,
	[otros] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblConceptosDesc]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblConceptosDesc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](200) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEmpleado]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmpleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[foto] [varchar](150) NULL,
	[usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblGastosSinComprobar]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGastosSinComprobar](
	[IdGastosSinComprobar] [int] IDENTITY(1,1) NOT NULL,
	[IdComprobacion] [int] NOT NULL,
	[IdProyecto] [varchar](50) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cantidad] [float] NOT NULL,
	[cantidadLetra] [varchar](100) NOT NULL,
	[destino] [varchar](100) NOT NULL,
	[fechaComision] [datetime] NOT NULL,
	[jefeInmediato] [varchar](100) NULL,
	[admonFinanzas] [varchar](100) NULL,
	[tipoComprobacion] [varchar](100) NULL,
 CONSTRAINT [PK_tblGastosSinComprobar] PRIMARY KEY CLUSTERED 
(
	[IdGastosSinComprobar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblHospedaje]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblHospedaje](
	[IdSolicitud] [int] NOT NULL,
	[concepto] [varchar](100) NOT NULL,
	[total] [float] NOT NULL,
	[numNoches] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOtrosGastos]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOtrosGastos](
	[IdSolicitud] [int] NOT NULL,
	[concepto] [varchar](100) NOT NULL,
	[numFrecuencia] [int] NOT NULL,
	[total] [float] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPersonasAsignadas]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersonasAsignadas](
	[IdProyecto] [int] NOT NULL,
	[IdPersonas] [int] NOT NULL,
 CONSTRAINT [PK_tblPersonasAsignadas] PRIMARY KEY CLUSTERED 
(
	[IdPersonas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPersonasSolicitud]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersonasSolicitud](
	[IdSolicitud] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdRelacion] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tblPersonasSolicitud] PRIMARY KEY CLUSTERED 
(
	[IdRelacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProyecto]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[nomProyecto] [varchar](100) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[montoDesayuno] [float] NULL,
	[montoComida] [float] NULL,
	[montoCena] [float] NULL,
	[nombreGerente] [varchar](100) NULL,
	[nombreJefe] [varchar](100) NULL,
	[nombreConta] [varchar](100) NULL,
 CONSTRAINT [PK_tblProyecto] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRelacionGastos]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRelacionGastos](
	[IdGastosSinComprobar] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[concepto] [varchar](100) NOT NULL,
	[importe] [float] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSolicitudV]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSolicitudV](
	[IdSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdProyecto] [varchar](50) NOT NULL,
	[fechaSolicitud] [datetime] NOT NULL,
	[destino] [varchar](100) NOT NULL,
	[fechaSalida] [datetime] NULL,
	[fechaRegreso] [datetime] NULL,
	[horaSalida] [varchar](50) NULL,
	[horaRegreso] [varchar](50) NULL,
	[monto] [float] NOT NULL,
	[numCuenta] [varchar](50) NOT NULL,
	[cantLetra] [varchar](50) NOT NULL,
	[totalDias] [int] NOT NULL,
	[totalGasto] [float] NOT NULL,
 CONSTRAINT [PK_tblSolicitudV] PRIMARY KEY CLUSTERED 
(
	[IdSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTotalDiario]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTotalDiario](
	[IdComprobacion] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[concepto] [varchar](100) NULL,
	[totalConceptoGen] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTotalGastos]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTotalGastos](
	[IdComprabacion] [int] NOT NULL,
	[boletos] [float] NULL,
	[otrosGastos] [float] NULL,
	[fecha] [datetime] NOT NULL,
	[totalViaje] [float] NOT NULL,
	[totalSinComprobar] [float] NULL,
	[saldo] [float] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblTransporte]    Script Date: 31/08/2015 12:01:45 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTransporte](
	[IdSolicitud] [int] NOT NULL,
	[conceptoo] [varchar](100) NOT NULL,
	[total] [float] NOT NULL,
	[numTransporte] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblAlimentos]  WITH CHECK ADD  CONSTRAINT [FK_tblAlimentos_tblSolicitudV] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[tblSolicitudV] ([IdSolicitud])
GO
ALTER TABLE [dbo].[tblAlimentos] CHECK CONSTRAINT [FK_tblAlimentos_tblSolicitudV]
GO
ALTER TABLE [dbo].[tblComprobacion]  WITH CHECK ADD  CONSTRAINT [FK_tblComprobacion_tblSolicitudV1] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[tblSolicitudV] ([IdSolicitud])
GO
ALTER TABLE [dbo].[tblComprobacion] CHECK CONSTRAINT [FK_tblComprobacion_tblSolicitudV1]
GO
ALTER TABLE [dbo].[tblComprobacionGastos]  WITH CHECK ADD  CONSTRAINT [FK_tblComprobacionGastos_tblComprobacion1] FOREIGN KEY([IdComprobacion])
REFERENCES [dbo].[tblComprobacion] ([Idcomprobacion])
GO
ALTER TABLE [dbo].[tblComprobacionGastos] CHECK CONSTRAINT [FK_tblComprobacionGastos_tblComprobacion1]
GO
ALTER TABLE [dbo].[tblGastosSinComprobar]  WITH CHECK ADD  CONSTRAINT [FK_tblGastosSinComprobar_tblComprobacion] FOREIGN KEY([IdComprobacion])
REFERENCES [dbo].[tblComprobacion] ([Idcomprobacion])
GO
ALTER TABLE [dbo].[tblGastosSinComprobar] CHECK CONSTRAINT [FK_tblGastosSinComprobar_tblComprobacion]
GO
ALTER TABLE [dbo].[tblHospedaje]  WITH CHECK ADD  CONSTRAINT [FK_tblHospedaje_tblSolicitudV] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[tblSolicitudV] ([IdSolicitud])
GO
ALTER TABLE [dbo].[tblHospedaje] CHECK CONSTRAINT [FK_tblHospedaje_tblSolicitudV]
GO
ALTER TABLE [dbo].[tblOtrosGastos]  WITH CHECK ADD  CONSTRAINT [FK_tblOtrosGastos_tblSolicitudV] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[tblSolicitudV] ([IdSolicitud])
GO
ALTER TABLE [dbo].[tblOtrosGastos] CHECK CONSTRAINT [FK_tblOtrosGastos_tblSolicitudV]
GO
ALTER TABLE [dbo].[tblPersonasAsignadas]  WITH CHECK ADD  CONSTRAINT [FK_tblPersonasAsignadas_tblProyecto] FOREIGN KEY([IdProyecto])
REFERENCES [dbo].[tblProyecto] ([IdProyecto])
GO
ALTER TABLE [dbo].[tblPersonasAsignadas] CHECK CONSTRAINT [FK_tblPersonasAsignadas_tblProyecto]
GO
ALTER TABLE [dbo].[tblPersonasSolicitud]  WITH CHECK ADD  CONSTRAINT [FK_tblPersonasSolicitud_tblPersonasAsignadas] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[tblPersonasAsignadas] ([IdPersonas])
GO
ALTER TABLE [dbo].[tblPersonasSolicitud] CHECK CONSTRAINT [FK_tblPersonasSolicitud_tblPersonasAsignadas]
GO
ALTER TABLE [dbo].[tblPersonasSolicitud]  WITH CHECK ADD  CONSTRAINT [FK_tblPersonasSolicitud_tblSolicitudV] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[tblSolicitudV] ([IdSolicitud])
GO
ALTER TABLE [dbo].[tblPersonasSolicitud] CHECK CONSTRAINT [FK_tblPersonasSolicitud_tblSolicitudV]
GO
ALTER TABLE [dbo].[tblRelacionGastos]  WITH CHECK ADD  CONSTRAINT [FK_tblRelacionGastos_tblGastosSinComprobar] FOREIGN KEY([IdGastosSinComprobar])
REFERENCES [dbo].[tblGastosSinComprobar] ([IdGastosSinComprobar])
GO
ALTER TABLE [dbo].[tblRelacionGastos] CHECK CONSTRAINT [FK_tblRelacionGastos_tblGastosSinComprobar]
GO
ALTER TABLE [dbo].[tblSolicitudV]  WITH CHECK ADD  CONSTRAINT [FK_tblSolicitudV_tblEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tblEmpleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[tblSolicitudV] CHECK CONSTRAINT [FK_tblSolicitudV_tblEmpleado]
GO
ALTER TABLE [dbo].[tblTotalDiario]  WITH CHECK ADD  CONSTRAINT [FK_tblTotalDiario_tblComprobacion1] FOREIGN KEY([IdComprobacion])
REFERENCES [dbo].[tblComprobacion] ([Idcomprobacion])
GO
ALTER TABLE [dbo].[tblTotalDiario] CHECK CONSTRAINT [FK_tblTotalDiario_tblComprobacion1]
GO
ALTER TABLE [dbo].[tblTotalGastos]  WITH CHECK ADD  CONSTRAINT [FK_tblTotalGastos_tblComprobacion1] FOREIGN KEY([IdComprabacion])
REFERENCES [dbo].[tblComprobacion] ([Idcomprobacion])
GO
ALTER TABLE [dbo].[tblTotalGastos] CHECK CONSTRAINT [FK_tblTotalGastos_tblComprobacion1]
GO
ALTER TABLE [dbo].[tblTransporte]  WITH CHECK ADD  CONSTRAINT [FK_tblTransporte_tblSolicitudV] FOREIGN KEY([IdSolicitud])
REFERENCES [dbo].[tblSolicitudV] ([IdSolicitud])
GO
ALTER TABLE [dbo].[tblTransporte] CHECK CONSTRAINT [FK_tblTransporte_tblSolicitudV]
GO
USE [master]
GO
ALTER DATABASE [dbMaster-V] SET  READ_WRITE 
GO
