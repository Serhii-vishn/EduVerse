﻿global using System.Text;
global using System.Text.RegularExpressions;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Extensions.Options;

global using AutoMapper;
global using EduVerse.API.Configuration;
global using EduVerse.API.Exceptions;
global using EduVerse.API.Data;
global using EduVerse.API.Data.Entities;
global using EduVerse.API.Data.EntityConfigurations;
global using EduVerse.API.Models.DTO;
global using EduVerse.API.Models.Enums;
global using EduVerse.API.Models.Requests;
global using EduVerse.API.Models.Responses;
global using EduVerse.API.Repositories;
global using EduVerse.API.Repositories.Interfaces;
global using EduVerse.API.Services;
global using EduVerse.API.Services.Interfaces;
global using EduVerse.API.Mapping.Resolvers;
