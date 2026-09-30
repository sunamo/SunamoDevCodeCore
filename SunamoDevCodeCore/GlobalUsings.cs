global using System.Collections.Generic;

global using System;
global using System.Linq;
global using System.Text;
global using System.Collections;
global using System.IO;
global using System.Threading.Tasks;
global using System.Diagnostics;
global using System.Text.RegularExpressions;
global using System.Xml.Linq;
global using System.Reflection;
global using System.Net;
global using System.Runtime.CompilerServices;
global using System.Xml;
global using System.Diagnostics.CodeAnalysis;
global using System.Runtime.Versioning;
global using System.Web;
global using Case.NET.Extensions;
global using HtmlAgilityPack;
global using Diacritics.Extensions;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;
global using ILogger = Microsoft.Extensions.Logging.ILogger;
global using NullLogger = Microsoft.Extensions.Logging.Abstractions.NullLogger;
global using SunamoDevCode;
global using SunamoDevCodeCore;
global using SunamoDevCodeCore.Constants;
global using SunamoDevCodeCore.Data;
global using SunamoDevCodeCore.Helpers;
global using SunamoDevCodeCore.Interfaces;
global using SunamoDevCodeCore.Services;
global using SunamoDevCodeCore.Templates;
global using SunamoDevCodeCore._sunamo.SunamoCSharp;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase;
global using SunamoDevCodeCore._sunamo.SunamoCSharp.SunamoCSharp;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase.Enums;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase.Values;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._public;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo;
global using SunamoDevCodeCore._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer;
global using SunamoDevCodeCore._sunamo.SunamoCSharp.SunamoCSharp.Helpers;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._public.SunamoCollectionWithoutDuplicates;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._public.SunamoTextOutputGenerator;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoArgs;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoBts;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoCollections;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoCollectionsChangeContent;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoEnumsHelper;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoExceptions;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoFileExtensions;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoFileSystem;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoGetFiles;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoRegex;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoString;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringFormat;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringGetLines;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringParts;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringSplit;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoStringTrim;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoTwoWayDictionary;
global using SunamoDevCodeCore._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer.Enums;
global using SunamoDevCodeCore._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer.Interfaces;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._public.SunamoData.Data;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._public.SunamoEnums.Enums;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoConverters.Converts;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoLang.SunamoI18N;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoLang.SunamoXlf;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoValues.All;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoValues.Values;
global using SunamoDevCodeCore._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer.Data.SolutionFolderNs;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase.Args;
global using SunamoDevCodeCore._sunamo.SunamoDevCodeBase._sunamo.SunamoInterfaces.Interfaces;
