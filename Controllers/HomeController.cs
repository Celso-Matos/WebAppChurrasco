using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppChurrasco.Data;
using WebAppChurrasco.ViewModel;
using WebAppChurrasco.Areas.Identity.Data;
using WebAppChurrasco.Areas.Identity.Pages.Account;
using WebAppChurrasco.Migrations;
using WebAppChurrasco.Entities;
using WebAppChurrasco.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace WebAppChurrasco.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly WebAppChurrascoContext _contexto;
        private readonly IChurrascoRepository _churrascoRepository;
        private readonly IParticipantesRepository _participantesRepository;
        private readonly IAgendaChurrasRepository _agendaChurrascoRepository;
        private readonly ILogger<LoginModel> _logger;
        private readonly WebAppChurrascoUser _user;

        public HomeController(WebAppChurrascoContext contexto,
                                IChurrascoRepository churrascoRepository,
                                IParticipantesRepository participantesRepository,
                                IAgendaChurrasRepository agendaChurrascoRepository,
                                ILogger<LoginModel> logger,
                                WebAppChurrascoUser user)
        {
            _contexto = contexto;
            _churrascoRepository = churrascoRepository;
            _participantesRepository = participantesRepository;
            _agendaChurrascoRepository = agendaChurrascoRepository;
            _logger = logger;
            _user = user;   
        }
        /// <summary>
        /// Exibe a lista da agenda de churras
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {                
                var _listaChurras = new WebAppChurrasco.ViewModel.Churrasco
                {
                    ListaChurras = _churrascoRepository.ListChurrasco()
                };                

                return View(_listaChurras);
            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }            
        }

        /// <summary>
        /// Exige a lista da agenda de churras com funcionalidades que podem ser
        /// disponibilizadas de acordo com o usuário de acesso
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AgendaChurrasco()
        {
            try
            {
                var _listaChurras = new WebAppChurrasco.ViewModel.Churrasco
                {
                    ListaChurras = _churrascoRepository.ListChurrasco()
                };

                return View(_listaChurras);
            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }            
        }

        /// <summary>
        /// Exibe o formuário para incluir nova agenda de churras
        /// Essa opção está disponível a todos os usuários mas pode ser 
        /// Implementado controle de acesso
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult NovoChurrasco()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }            
        }

        /// <summary>
        /// Inclui nova agenda churras
        /// </summary>
        /// <param name="churrasco"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> NovoChurrasco(WebAppChurrasco.ViewModel.Churrasco churrasco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(churrasco.DataChurras < DateTime.Now)
                    {
                        TempData["msgRetorno"] = "A Data do Churras deve ser maior ou igual a data de hoje!";

                        return View(churrasco);
                    }

                    var _churrasco = new WebAppChurrasco.Entities.Churrasco
                    {
                        DescChurras = churrasco.DescChurras,
                        ObsAdsChurras = churrasco.ObsAdsChurras,
                        DataChurras = churrasco.DataChurras,
                        DataCriacaoChurras = DateTime.Now,
                        IdUserCriacao = _user.Id
                    };

                    await _churrascoRepository.NovoChurrasco(_churrasco);

                    TempData["msgRetorno"] = "Sucesso";

                    return View(churrasco);
                }

                return View();
            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }            
        }

        /// <summary>
        /// Exibe a tela para gestão da agenda churras onde é possível
        /// Adicionar e remover participantes
        /// Para participar da agenda churras é utilizada a lista de usuários
        /// Registrados no sistema        
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AcaoParticipantesChurras(int id)
        {
            try
            {
                var _churrasco = _churrascoRepository.GetChurrascosById(id);
                var _participantes = _participantesRepository.ListParticipantesChurras(id);
                var _usuarios = _participantesRepository.GetUsers().Where(a => !_participantes.Any(b => b.Id == a.Id & b.StatusParticipantes == true));
                var _listaAgendaChurras = _agendaChurrascoRepository.AgendaChurras(id);

                var _viewModel = new WebAppChurrasco.ViewModel.Churrasco
                {

                    IdChurras = _churrasco.IdChurras,
                    DescChurras = _churrasco.DescChurras,
                    ObsAdsChurras = _churrasco.ObsAdsChurras,
                    DataChurras = _churrasco.DataChurras,
                    GetUsers = _usuarios,
                    ListaAgendaChurras = _listaAgendaChurras.Where(c => c.IdParticipantes > 0)
                };
                
                TempData["msgRetorno"] = "";
                
                if (_viewModel.GetUsers.Count() <= 0)
                {
                    TempData["msgRetorno"] = "Não há usuário cadastrado no sistema para participar do Churras!";
                }

                return View(_viewModel);
            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }
        }
        
        /// <summary>
        /// Inclui participantes na agenda churras
        /// </summary>
        /// <param name="churrasco"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AcaoParticipantesChurras(WebAppChurrasco.ViewModel.Churrasco churrasco)
        {
            try
            {
                var _participantes = new WebAppChurrasco.Entities.Participantes
                {
                    IdChurras = churrasco.IdChurras,
                    Id = churrasco.ListaUsuarios[0].ToString(),
                    VlContribuicao = churrasco.VlContribuicao,
                    VlSugeridoComBebida = churrasco.VlSugeridoComBebida,
                    VlSugeridoSemBebida = churrasco.VlSugeridoSemBebida,
                    DataCriacaoParticipantes = DateTime.Now,
                    IdUserCriacao = _user.Id,
                    StatusParticipantes = true,
                    DataStatusParticipantes = DateTime.Now,
                    IdUserStatus = _user.Id,
                };

                //Adicionar participantes
                await _participantesRepository.AdicionarParticipantesChurras(_participantes);
                var _listaParticipantes = _participantesRepository.ListParticipantesChurras(_participantes.IdChurras);
                var _listaUsuarios = _participantesRepository.GetUsers().Where(a => !_listaParticipantes.Any(b => b.Id == a.Id & b.StatusParticipantes == true));

                churrasco.GetUsers = _listaUsuarios;
                churrasco.ListaAgendaChurras = _agendaChurrascoRepository.AgendaChurras(_participantes.IdChurras) as IList<AgendaChurras>;           

                
                TempData["msgRetorno"] = "Sucesso";

                return View(churrasco);

            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }

        }

        /// <summary>
        /// Remove participantes da agenda churras
        /// A remoção não exclui registro para manutenção do histórico apenas altera o status do participante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RemoverParticipantes(int id)
        {
            try
            {
                var _participantes = _participantesRepository.GetParticipantes(id);                
                
                if (_participantes.Count > 0)
                {
                    foreach (var item in _participantes)
                    {
                        item.StatusParticipantes = false;
                        item.DataStatusParticipantes = DateTime.Now;
                        item.IdUserStatus = _user.Id;

                        _participantesRepository.RemoverParticipantesChurras(item);                        

                    };
                }

                TempData["msgRetorno"] = "Sucesso";

                return RedirectToAction(nameof(AcaoParticipantesChurras), new { id = _participantes.Select(c => c.IdChurras).FirstOrDefault() });

            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }
        }

        /// <summary>
        /// Exibe os detalhes do churrasco como total de participantes, valor arrecadado e lista de participantes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DetalhesAgendaChurras(int id)
        {
            try
            {
                var _churrasco = _churrascoRepository.GetChurrascosById(id);
                var _participantes = _participantesRepository.ListParticipantesChurras(id);
                var _usuarios = _participantesRepository.GetUsers().Where(a => !_participantes.Any(b => b.Id == a.Id & b.StatusParticipantes == true));
                var _listaAgendaChurras = _agendaChurrascoRepository.AgendaChurras(id);

                var _viewModel = new WebAppChurrasco.ViewModel.Churrasco
                {

                    IdChurras = _churrasco.IdChurras,
                    DescChurras = _churrasco.DescChurras,
                    ObsAdsChurras = _churrasco.ObsAdsChurras,
                    DataChurras = _churrasco.DataChurras,
                    GetUsers = _usuarios,
                    ListaAgendaChurras = _listaAgendaChurras.Where(c => c.IdParticipantes > 0),
                    TotalParticipantes = _listaAgendaChurras.Where(c => c.IdParticipantes > 0).Count(),
                    ValorArrecadado = _listaAgendaChurras.Sum(x => x.VlContribuicao)
                };

                return View(_viewModel);
            }
            catch (Exception)
            {
                TempData["msgRetorno"] = "Erro";
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new WebAppChurrasco.ViewModel.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}