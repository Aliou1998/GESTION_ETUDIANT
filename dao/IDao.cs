﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiat.dao
{
   public interface IDao<T>
    {
         int Insert(T obj);

    }
}
