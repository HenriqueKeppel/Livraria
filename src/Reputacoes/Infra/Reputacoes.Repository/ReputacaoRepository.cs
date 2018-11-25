using System;
using System.Collections.Generic;
using Reputacoes.Domain.Interfaces;
using Reputacoes.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Reputacoes.Repository
{
    public class ReputacaoRepository : IReputacaoRepository
    {
        private List<Reputacao> _virtualRepository;
        private string _virtualRepositoryFile;

        public ReputacaoRepository()
        {
            _virtualRepository = new List<Reputacao>();
            _virtualRepositoryFile = "ReputacaoRepository.txt";

            // Carregar a lista com o tiver no arquivo.
            ReadFile();
        }

        public async Task<bool> Adicionar(Reputacao item)
        {
            _virtualRepository.Add(item);

            WriteListInFile();

            return true;
        }

        public async Task<bool> Remover(string isbn, int id)
        {
            DestroyFile();

            _virtualRepository.Remove(_virtualRepository.Where(x => x.Isbn == isbn && x.Id == id).FirstOrDefault());
            
            WriteListInFile();
            return true;
        }
        public async Task<IEnumerable<Reputacao>> Obter(string isbn)
        {
            return _virtualRepository.Where(x => x.Isbn == isbn);
        }

        private void WriteListInFile()
        {
            using (StreamWriter fileWriter = new StreamWriter(_virtualRepositoryFile))
            {
                foreach (Reputacao item in _virtualRepository)
                {
                    fileWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        private void ReadFile()
        {
            using (StreamReader fileReader = new StreamReader(_virtualRepositoryFile))
            {
                while (fileReader.Peek() >= 0)
                {
                    string line = fileReader.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    _virtualRepository.Add(JsonConvert.DeserializeObject<Reputacao>(line));
                }
            }
        }

        private void DestroyFile()
        {
            File.Delete(_virtualRepositoryFile);
        }
    }
}
