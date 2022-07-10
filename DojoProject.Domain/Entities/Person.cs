using DojoProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoProject.Domain.Entities
{
    public class Person : EntityBase<Guid>
    {
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public GenderType Gender { get; set; }
        [StringLength(255)]
        public string Age { get; set; }
        [StringLength(255)]
        public string Identification { get; set; }
        [StringLength(255)]
        public string Address { get; set; }

        public Person(string name, GenderType gender, string age, string identification, string address)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Identification = identification;
            Address = address;
        }

        public Person()
        {
        }

        public enum GenderType { Masculino, Femenino, Otro }

    }
}
