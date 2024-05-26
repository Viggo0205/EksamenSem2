CREATE TABLE [dbo].[Kompetence] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Navn]        VARCHAR (255) NULL,
    [Beskrivelse] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Medarbejder] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Løn]         FLOAT (53)     NULL,
    [Timeløn]     FLOAT (53)     NULL,
    [Beskrivelse] NVARCHAR (MAX) NULL,
    [RolleId]     INT            NULL,
    [Navn]        NVARCHAR (255) NULL,
    [Email]       VARCHAR (255)  NULL,
    [TlfNr]       INT            NULL,
    [Password]    VARCHAR (255)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RolleId]) REFERENCES [dbo].[Rolle] ([Id])
);
CREATE TABLE [dbo].[MedarbejderKompetence] (
    [Kompetence_ID]  INT NOT NULL,
    [Medarbejder_ID] INT NOT NULL,
    CONSTRAINT [MedarbejderKompetence_ID] PRIMARY KEY CLUSTERED ([Medarbejder_ID] ASC, [Kompetence_ID] ASC),
    FOREIGN KEY ([Medarbejder_ID]) REFERENCES [dbo].[Medarbejder] ([Id]),
    FOREIGN KEY ([Kompetence_ID]) REFERENCES [dbo].[Kompetence] ([Id])
);
CREATE TABLE [dbo].[PlanData] (
    [Plan_id]    INT      IDENTITY (1, 1) NOT NULL,
    [StartDato]  DATE     NULL,
    [StartTid]   TIME (7) NULL,
    [SlutDato]   DATE     NULL,
    [SlutTid]    TIME (7) NULL,
    [TotalTimer] INT      NULL,
    PRIMARY KEY CLUSTERED ([Plan_id] ASC)
);
CREATE TABLE [dbo].[Rolle] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Navn]        VARCHAR (255) NULL,
    [Rettigheder] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[VagtPlan] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [MedarbejderId] INT        NOT NULL,
    [PlanId]        INT        NOT NULL,
    [Overtid]       FLOAT (53) NULL,
    [Beskrivelse]   TEXT       NULL,
    [Godekente]     BIT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MedarbejderId]) REFERENCES [dbo].[Medarbejder] ([Id]),
    FOREIGN KEY ([PlanId]) REFERENCES [dbo].[PlanData] ([Plan_id])
);