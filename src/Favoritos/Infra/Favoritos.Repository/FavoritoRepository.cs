using System;
using System.Collections.Generic;
using Favoritos.Domain.Interfaces;
using Favoritos.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Favoritos.Repository
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private List<Favorito> _virtualRepository;
        private string _virtualRepositoryFile;

        public FavoritoRepository()
        {
            _virtualRepository = new List<Favorito>();
            _virtualRepositoryFile = "virtualDRepository.txt";

            // Carregar a lista com o tiver no arquivo.
            ReadFile();
        }

        public async Task<bool> Adicionar(Favorito item)
        {
            _virtualRepository.Add(item);

            WriteListInFile();

            return true;
        }

        public async Task<bool> Remover(string isbn)
        {
            DestroyFile();

            _virtualRepository.Remove(_virtualRepository.Where(x => x.Isbn == isbn).FirstOrDefault());
            
            WriteListInFile();
            return true;
        }
        public async Task<Favorito> Obter(string isbn)
        {
            return _virtualRepository.Where(x => x.Isbn == isbn).FirstOrDefault();
        }

        public async Task<IEnumerable<Favorito>> Obter()
        {
            return _virtualRepository;
        }

        private void WriteListInFile()
        {
            using (StreamWriter fileWriter = new StreamWriter(_virtualRepositoryFile))
            {
                foreach (Favorito item in _virtualRepository)
                {
                    fileWriter.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        private void WriteInFile(string line)
        {
            using (StreamWriter fileWriter = new StreamWriter(_virtualRepositoryFile))
            {
                fileWriter.WriteLine(line);
            }
        }

        private void ReadFile()
        {
            using (StreamReader fileReader = new StreamReader(_virtualRepositoryFile))
            {
                string line = fileReader.ReadLine();

                if (!string.IsNullOrEmpty(line))
                    _virtualRepository.Add(JsonConvert.DeserializeObject<Favorito>(line));
            }
        }

        private void DestroyFile()
        {
            File.Delete(_virtualRepositoryFile);
        }
    }
}
