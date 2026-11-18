# How to Contribute

A short guide to working on **Evently-Project** with Git and GitHub.

**Rule #1:** Everyone works on their **own branch, named after themselves** (e.g. `juan`, `maria`). Nobody pushes directly to `main`.

## One-time setup

1. Install [Git](https://git-scm.com/downloads).
2. Make a [GitHub](https://github.com) account and ask the project owner to add you as a **collaborator**.
3. Tell Git who you are:

```bash
git config --global user.name "Your Name"
git config --global user.email "you@example.com"
```

4. Clone the project:

```bash
git clone https://github.com/aldrsze/Evently-Project.git
cd Evently-Project
```

5. Create your personal branch (use your own name, lowercase, no spaces):

```bash
git checkout -b yourname
git push -u origin yourname
```

You only do this once. From now on, `yourname` is your branch.

## The workflow (do this every time)

### 1. Switch to your branch and get the latest code

```bash
git checkout yourname
git pull origin main
```

### 2. Do your work

Edit files, then test that they actually run.

### 3. Save your changes (commit)

```bash
git add .
git commit -m "Add login page"
```

Write a short message saying **what** you did.

### 4. Upload your branch

```bash
git push origin yourname
```

### 5. Open a Pull Request (PR)

1. Go to the repo on GitHub.
2. Click **Compare & pull request** (the yellow banner), or go to **Pull requests → New pull request**.
3. Set **base: `main`** and **compare: `yourname`**.
4. Write a short description of what you changed.
5. Click **Create pull request**.
6. Ask a teammate to review it, then **Merge**.

### 6. Stay up to date

After your PR is merged (or when teammates merge theirs), pull the latest into your branch before continuing:

```bash
git checkout yourname
git pull origin main
```

## Rules

- Only work on your own branch.
- Always `git pull origin main` before you start working.
- Small commits, clear messages.
- Don't push straight to `main`.
- Read and understand code before committing it, especially if AI wrote it. If you can't explain it, don't submit it.

## Merge conflicts

Happens when two people edit the same lines. Don't panic:

```bash
git checkout yourname
git pull origin main
```

Git marks the conflicts in the file like this:

```
<<<<<<< HEAD
your version
=======
their version
>>>>>>> main
```

Pick what to keep, delete the marker lines, then:

```bash
git add .
git commit -m "Resolve merge conflict"
git push origin yourname
```

Still stuck? Ask the team before guessing.

## Cheat sheet

| Command | What it does |
|---|---|
| `git status` | See what changed |
| `git branch` | Show which branch you're on |
| `git checkout yourname` | Switch to your branch |
| `git pull origin main` | Get latest code from main |
| `git add .` | Stage all changes |
| `git commit -m "msg"` | Save changes locally |
| `git push origin yourname` | Upload your branch |
