using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class ReviewerRepository : IReviewerRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReviewerRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public ICollection<Reviewer> GetReviewers()
    {
        return _context.Reviewers.ToList();
    }

    public Reviewer GetReviewer(int reviewerId)
    {
        return _context.Reviewers.Where(r => r.Id == reviewerId)
            .Include(e => e.Reviews)
            .FirstOrDefault();
    }

    public ICollection<Review> GetReviewsByReviewers(int reviewerId)
    {
        return _context.Reviews.Where(rv => rv.Reviewer.Id == reviewerId).ToList();
    }

    public bool ReviewerExists(int reviewId)
    {
        return _context.Reviewers.Any(r => r.Id == reviewId);
    }
}