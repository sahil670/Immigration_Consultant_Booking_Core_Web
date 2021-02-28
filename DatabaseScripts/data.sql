SET IDENTITY_INSERT [dbo].[Agency] ON
INSERT INTO [dbo].[Agency] ([Id], [Name], [WebSite]) VALUES (1, N'Study Overseas ', N'http://www.StudyOverseas.com')
INSERT INTO [dbo].[Agency] ([Id], [Name], [WebSite]) VALUES (2, N'Education Consultants', N'http://www.educationcons.com')
SET IDENTITY_INSERT [dbo].[Agency] OFF
SET IDENTITY_INSERT [dbo].[Client] ON
INSERT INTO [dbo].[Client] ([Id], [Name], [Email]) VALUES (1, N'Ani Sharma', N'AniSharma@gmail.com')
INSERT INTO [dbo].[Client] ([Id], [Name], [Email]) VALUES (2, N'Shane Franklin', N'shane@gmail.com')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Consultant] ON
INSERT INTO [dbo].[Consultant] ([Id], [Name], [Email], [AgencyId]) VALUES (1, N'Jay Raymond', N'jay@consultants.com', 1)
INSERT INTO [dbo].[Consultant] ([Id], [Name], [Email], [AgencyId]) VALUES (2, N'Wilson Kelly', N'wilson@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[Consultant] OFF
SET IDENTITY_INSERT [dbo].[ConsultationBooking] ON
INSERT INTO [dbo].[ConsultationBooking] ([Id], [ClientId], [ConsultantId]) VALUES (1, 2, 2)
INSERT INTO [dbo].[ConsultationBooking] ([Id], [ClientId], [ConsultantId]) VALUES (2, 1, 1)
SET IDENTITY_INSERT [dbo].[ConsultationBooking] OFF
