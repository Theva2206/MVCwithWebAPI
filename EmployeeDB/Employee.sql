CREATE TABLE [dbo].[Employees](  
    [Id] [nvarchar](50) NOT NULL,  
    [Name] [nvarchar](50) NULL,  
    [Address] [nvarchar](50) NULL,  
    [Gender] [nvarchar](10) NULL,  
    [Company] [nvarchar](50) NULL,  
    [Designation] [nvarchar](50) NULL,  
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED   
    (  
        [Id] ASC  
    )  
)  