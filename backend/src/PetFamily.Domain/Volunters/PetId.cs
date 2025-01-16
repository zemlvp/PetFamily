﻿using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunters;

public record PetId 
{
    private PetId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    public static PetId NewPetId()  => new(Guid.NewGuid());
    public static PetId Empty()  => new(Guid.Empty);
}