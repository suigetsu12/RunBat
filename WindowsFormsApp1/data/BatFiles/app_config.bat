
call _path.bat
:: --------------------------- The PATH of all project  ----------------------------------------
set coreSourceUrl=%rootPathProject%CoreService\Auvenir.Web

set fsSourceUrl=%rootPathProject%FileService\Auvenir.FileService.WebApi

set pm_psSourceUrl=%rootPathProject%PlanningStepService\PlanningStep

set pm_snSourceUrl=%rootPathProject%CommonToolService

set pm_vsaSourceUrl=%rootPathProject%NonAccountWorkingPaperService

set wpSourceUrl=%rootPathProject%AccountWorkingPaperService\Auvenir.WorkingPaper

set feSourceUrl=%rootPathProject%FrontEnd

set spoApiSourceUrl=%rootPathProject%SPOApi

set spo_SPOSetupProcessorSourceUrl=%rootPathProject%SPOSetupProcessor

set fileServicesUrl=%rootPathProject%FileService\Auvenir.FileService.WebApi

set fileIntegrityCheckProcessorUrl=%rootPathProject%FileIntegrityCheckProcessor\Auvenir.FileIntegrityCheckProcessor

set archiveSourceUrl=%rootPathProject%ArchivingWebJob\Archiving.WebJob

set archiveApiSourceUrl=%rootPathProject%ArchivingWebAPI\Archiving.WebAPI

set contentProcessorSourceUrl=%rootPathProject%ContentProcessorService\Auvenir.ContentProcessor

set carryforwardProcessorSourceUrl=%rootPathProject%Carryforward\Auvenir.CarryforwardProcessor

set carryforwardContentProcessorSourceUrl=%rootPathProject%Carryforward\Auvenir.CfContentProcessor

set carryforwardCopyEngProcessorSourceUrl=%rootPathProject%Carryforward\Auvenir.CopyEngProcessor

set carryforwardFileTransferProcessorSourceUrl=%rootPathProject%Carryforward\Auvenir.FileTransferProcessor

set houseKeeperProcessorSourceUrl=%rootPathProject%HouseKeeperProcessor

set AuvenirDuplicateEngCommonUrl=%rootPathProject%DuplicateEngagement\Auvenir.DuplicateEng.Common

set AuvenirDuplicateEngProcessorUrl=%rootPathProject%DuplicateEngagement\Auvenir.DuplicateEngProcessor

set AuvenirDuplicateFileProcessorUrl=%rootPathProject%DuplicateEngagement\Auvenir.DuplicateFileProcessor

set IntegrationHubServiceUrl= %rootPathProject%IntegrationHubService\Auvenir.IntegrationHubService

set AuvenirIntegrationHubProcessorUrl= %rootPathProject%IntegrationHubProcessor\Auvenir.IntegrationHubProcessor

:: --------------------------- The PATH you want to build to   ----------------------------------------

set coreOutputUrl=%rootPathStart%CoreService

set fsOutputUrl=%rootPathStart%FileServices

set pm_psOutputUrl=%rootPathStart%PlanningStepService

set pm_snOutputUrl=%rootPathStart%CommonToolService

set pm_vsaOutputUrl=%rootPathStart%NonAccountWorkingPaperService

set wpOutputUrl=%rootPathStart%AccountWorkingPaperService

set feOutputUrl=%rootPathStart%FrontEnd

set spoApiOutputUrl=%rootPathStart%SPOApi

set spo_SPOSetupProcessorOutputUrl=%rootPathStart%SPOSetupProcessor

set fileIntegrityCheckProcessorOutputUrl=%rootPathStart%FileIntegrityCheckProcessor

set fileServicesOutputUrl=%rootPathStart%FileServices

set archiveOutputUrl=%rootPathStart%ArchivingWebJob

set archiveApiOutputUrl=%rootPathStart%ArchivingWebAPI

set contentProcessorOutputUrl=%rootPathStart%ContentProcessor

set carryforwardProcessorOutputUrl=%rootPathStart%CarryforwardProcessor

set carryforwardContentProcessorOutputUrl=%rootPathStart%CarryforwardContentProcessor

set carryforwardCopyEngProcessorOutputUrl=%rootPathStart%CarryforwardCopyEngProcessor

set carryforwardFileTransferProcessorOutputUrl=%rootPathStart%CarryforwardFileTransferProcessor

set houseKeeperProcessorOutputUrl=%rootPathStart%HouseKeeperProcessor

set AuvenirDuplicateEngCommonOutputUrl=%rootPathStart%DuplicateEngCommon

set AuvenirDuplicateEngProcessorOutputUrl=%rootPathStart%DuplicateEngProcessor

set AuvenirDuplicateFileProcessorOutputUrl=%rootPathStart%DuplicateFileProcessor
set WpGenerationProcessorOutputUrl=%rootPathStart%WpGenerationProcessor

set AuvenirDuplicateEngCommonOutputUrl=%rootPathStart%Auvenir.DuplicateEng.Common

set AuvenirDuplicateEngProcessorOutputUrl=%rootPathStart%Auvenir.DuplicateEngProcessor

set AuvenirDuplicateFileProcessorOutputUrl=%rootPathStart%Auvenir.DuplicateFileProcessor

set integrationHubOutputUrl=%rootPathStart%IntegrationHubService

set AuvenirIntegrationHubProcessorOutputUrl=%rootPathStart%IntegrationHubProcessor