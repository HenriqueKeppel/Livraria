using System;
using System.Collections.Generic;
using Criticas.Domain.Interfaces;
using Criticas.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Criticas.Repository
{
    public class CriticaRepository : ICriticaRepository
    {
        private List<ItemCritica> _virtualRepository;
        private string _virtualRepositoryFile;

        public CriticaRepository()
        {
            _virtualRepository = new List<ItemCritica>();
            _virtualRepositoryFile = "CriticaRepository.txt";

            // Carregar a lista com o tiver no arquivo.
            ReadFile();
        }

        public async Task<bool> Adicionar(ItemCritica item)
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
        public async Task<IEnumerable<ItemCritica>> Obter(string isbn)
        {
            return _virtualRepository.Where(x => x.Isbn == isbn);
        }

        private void WriteListInFile()
        {
            using (StreamWriter fileWriter = new StreamWriter(_virtualRepositoryFile))
            {
                foreach (ItemCritica item in _virtualRepository)
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
                    _virtualRepository.Add(JsonConvert.DeserializeObject<ItemCritica>(line));
                }
            }
        }

        private void DestroyFile()
        {
            File.Delete(_virtualRepositoryFile);
        }
    }
}
