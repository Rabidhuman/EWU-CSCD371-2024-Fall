﻿using CanHazFunny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;
public class Jester
{
    private IJokeService? _jokeService;
    private IDisplayJokes? _displayJokes;

    public IJokeService JokeService
    {
        get => _jokeService!;
        set => _jokeService = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IDisplayJokes DisplayJokes
    {
        get => _displayJokes!;
        set => _displayJokes = value ?? throw new ArgumentNullException(nameof(value));
    }

    // TODO: Consider altering the constructor to populate default values
    public Jester(IJokeService jokeService, IDisplayJokes displayJokes)
    {
        JokeService = jokeService;
        DisplayJokes = displayJokes;
    }

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = JokeService.GetJoke();
        } while (joke.Contains("Chuck") || joke.Contains("Norris"));

        DisplayJokes.OutputJoke(joke);
    }
}
