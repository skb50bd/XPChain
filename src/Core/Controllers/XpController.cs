using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core.Controllers
{
    [ApiController]
    public class XpController : ControllerBase
    {
        private readonly ILedgerRepository _ledger;
        public XpController(
            ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        [HttpGet("/ledger/Chain")]
        public IEnumerable<Block> GetChain()
        {
            return _ledger.GetAll();
        }

        [HttpGet("/ledger/BlockByHash/{hash}")]
        public Block GetByHash([FromRoute]string hash)
        {
            return _ledger.GetByHash(hash);
        }

        [HttpGet("/ledger/NextBlock/{currentBlockHash}")]
        public Block GetNextBlock(string currentBlockHash)
        {
            return _ledger.GetNextBlock(currentBlockHash);
        }

        [HttpGet("/ledger/LastHash")]
        public string GetLastBlockHash()
        {
            return _ledger.GetLastBlockHash();
        }

        [HttpGet("/ledger/LastBlock")]
        public Block GetLastBlock()
        {
            return _ledger.GetLastBlock();
        }

        [HttpGet("/ledger/Length")]
        public int GetChainLength()
        {
            return _ledger.GetChainLength();
        }

        [HttpGet("/ledger/Genesis")]
        public Block GetGenesisBlock()
        {
            return _ledger.GetGenesisBlock();
        }

        [HttpPost("/ledger/InsertBlock")]
        public Block PostBlock(Block block)
        {
            var orgs = _ledger.GetAll<Organization>();
            Block b = _ledger.GetById(block.Id);
            if(b == null)
            {
                var validOrg = orgs.Any(o => o.PublicKey == block.Originator);

                if (validOrg)
                    _ledger.Insert(block);
            }
           
            throw new KeyNotFoundException();
        }


    }
}
